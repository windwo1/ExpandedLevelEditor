import os
import bpy
import re
import xml.etree.cElementTree as ET
from bpy.props import StringProperty, BoolProperty
from bpy.types import Operator
from mathutils import Matrix, Vector

def remove_suffix(name):
    return re.sub(r'\.\d+$', '', name)

def fix_filename(name):
    return re.sub(r'[<>:"/\\|?*]', '_', name)

class ExportFolderOperator(Operator):
    bl_idname = "export_scene.level_folder"
    bl_label = "Select Level Folder"

    directory: StringProperty(
        name="Outdir Path",
        description="Select the level folder",
        subtype="DIR_PATH"
    )

    filter_folder: BoolProperty(
        default=True,
        options={"HIDDEN"}
    )

    def execute(self, context):
        os.makedirs(os.path.join(self.directory, "Meshes"), exist_ok=True)

        objects = []
        exported_meshes = {}
        written_meshes = set()

        collision_collection_name = "Collision"
        collision_collection = bpy.data.collections[collision_collection_name]

        use_undo = context.preferences.edit.use_global_undo
        context.preferences.edit.use_global_undo = False

        prev_selected = list(context.selected_objects)
        prev_active = context.view_layer.objects.active

        for obj in prev_selected:
            obj.select_set(False)

        try:
            for obj in bpy.data.objects:
                if obj.type != "MESH":
                    continue

                if len(obj.data.uv_layers) < 1:
                    continue

                if obj.users_collection[0].name == collision_collection_name:
                    continue

                mesh_name = fix_filename(obj.data.name)

                exported_meshes[obj.name] = mesh_name
                objects.append(obj)

                if mesh_name in written_meshes:
                    continue

                written_meshes.add(mesh_name)

                exported_obj = obj.copy()
                exported_obj.data = obj.data.copy()
                exported_obj.parent = None
                exported_obj.matrix_world = Matrix.Identity(4)

                if ":lod0" not in obj.name:
                    # so that frosty can import the objs
                    exported_obj.name += ":lod0"

                context.collection.objects.link(exported_obj)

                exported_obj.select_set(True)
                context.view_layer.objects.active = exported_obj

                path = os.path.join(self.directory, "Meshes", mesh_name + ".fbx")

                if not os.path.exists(path):
                    bpy.ops.export_scene.fbx(filepath=path, use_selection=True, global_scale=0.01, use_triangles=True, use_tspace=True)

                bpy.data.objects.remove(exported_obj, do_unlink=True)
        finally:
            for obj in prev_selected:
                if obj.name in bpy.data.objects:
                    obj.select_set(True)

            if prev_active is not None and prev_active.name in bpy.data.objects:
                context.view_layer.objects.active = prev_active

            context.preferences.edit.use_global_undo = use_undo

        def write_vec3(parent, vec):
            x_element = ET.SubElement(parent, "X")
            x_element.text = str(vec.x)
            y_element = ET.SubElement(parent, "Y")
            y_element.text = str(vec.y)
            z_element = ET.SubElement(parent, "Z")
            z_element.text = str(vec.z)

        def write_quaternion(parent, q):
            x_element = ET.SubElement(parent, "X")
            x_element.text = str(q.x)
            y_element = ET.SubElement(parent, "Y")
            y_element.text = str(q.y)
            z_element = ET.SubElement(parent, "Z")
            z_element.text = str(q.z)
            w_element = ET.SubElement(parent, "W")
            w_element.text = str(q.w)

        def write_transform(parent, transform):
            location = transform.translation.copy()
            rotation = transform.to_quaternion().normalized()
            scale = transform.to_scale()

            location_element = ET.SubElement(parent, "Location")
            write_vec3(location_element, location)
            rotation_element = ET.SubElement(parent, "Quaternion")
            write_quaternion(rotation_element, rotation)
            scale_element = ET.SubElement(parent, "Scale")
            write_vec3(scale_element, scale)

        def write_bbox(parent, obj):
            bbox = []
            for corner in obj.bound_box:
                bbox.append(Vector(corner))

            min_x = None
            min_y = None
            min_z = None

            for v in bbox:
                if min_x is None or v.x < min_x:
                    min_x = v.x

                if min_y is None or v.y < min_y:
                    min_y = v.y

                if min_z is None or v.z < min_z:
                    min_z = v.z

            max_x = None
            max_y = None
            max_z = None

            for v in bbox:
                if max_x is None or v.x > max_x:
                    max_x = v.x

                if max_y is None or v.y > max_y:
                    max_y = v.y

                if max_z is None or v.z > max_z:
                    max_z = v.z

            bbox_min = Vector((min_x, min_y, min_z))
            bbox_max = Vector((max_x, max_y, max_z))

            min_element = ET.SubElement(parent, "Min")
            write_vec3(min_element, bbox_min)
            max_element = ET.SubElement(parent, "Max")
            write_vec3(max_element, bbox_max)

        def export_objects(xml_path):
            root = ET.Element("Objects")

            for obj in objects:
                mat_name = ""
                if len(obj.material_slots) > 0:
                    mat_name = obj.material_slots[0].material.name

                obj_element = ET.SubElement(root, "Object")
                name_element = ET.SubElement(obj_element, "Name")
                name_element.text = fix_filename(obj.name)
                mesh_element = ET.SubElement(obj_element, "Mesh")
                mesh_element.text = exported_meshes[obj.name] + ".fbx"
                mat_element = ET.SubElement(obj_element, "Material")
                mat_element.text = mat_name

                bbox_element = ET.SubElement(obj_element, "BoundingBox")
                write_bbox(bbox_element, obj)    

                transform_element = ET.SubElement(obj_element, "Transform")
                write_transform(transform_element, obj.matrix_world)

            tree = ET.ElementTree(root)
            ET.indent(tree, space="    ")
            tree.write(xml_path)
        
        def export_materials(xml_path):
            root = ET.Element("Materials")

            for mat in bpy.data.materials:
                material_element = ET.SubElement(root, "Material")

                name_element = ET.SubElement(material_element, "Name")
                name_element.text = mat.name

                tint = mat.node_tree.nodes["Principled BSDF"].inputs["Base Color"].default_value
                tint_element = ET.SubElement(material_element, "Tint")
                write_vec3(tint_element, Vector((tint[0], tint[1], tint[2])))

                textures_element = ET.SubElement(material_element, "Textures")

                for node in list(mat.node_tree.nodes):
                    if node.type != "TEX_IMAGE":
                        continue

                    image = node.image

                    if not image:
                        continue

                    if image.source != "FILE":
                        continue

                    texture_path = bpy.path.abspath(image.filepath)

                    texture_element = ET.SubElement(textures_element, "Texture")
                    texture_element.text = texture_path

            tree = ET.ElementTree(root)
            ET.indent(tree, space="    ")
            tree.write(xml_path)

        def export_collision(xml_path):
            if collision_collection is None:
                return

            root = ET.Element("Collisions")
            
            for obj in bpy.data.objects:
                if obj.users_collection[0].name != collision_collection_name:
                    continue

                objType = ""
                if obj.name.startswith("Cube"):
                    objType = "Cube"
                elif obj.name.startswith("Sphere"):
                    objType = "Sphere"

                if objType == "":
                    continue

                collision_element = ET.SubElement(root, "Collision")

                type_element = ET.SubElement(collision_element, "Type")
                type_element.text = objType

                bbox_element = ET.SubElement(collision_element, "BoundingBox")
                write_bbox(bbox_element, obj)

                transform_element = ET.SubElement(collision_element, "Transform")
                write_transform(transform_element, obj.matrix_world)

            tree = ET.ElementTree(root)
            ET.indent(tree, space="    ")
            tree.write(xml_path)

        obj_xml_path = os.path.join(self.directory, "Objects.xml")
        materials_xml_path = os.path.join(self.directory, "Materials.xml")
        collisions_xml_path = os.path.join(self.directory, "Collisions.xml")
        
        export_objects(obj_xml_path)
        export_materials(materials_xml_path)
        export_collision(collisions_xml_path)
            
        return { "FINISHED" }

    def invoke(self, context, event):
        context.window_manager.fileselect_add(self)
        return {"RUNNING_MODAL"}


def register():
    bpy.utils.register_class(ExportFolderOperator)
    bpy.ops.export_scene.level_folder("INVOKE_DEFAULT")


def unregister():
    bpy.utils.unregister_class(ExportFolderOperator)


if __name__ == "__main__":
    register()