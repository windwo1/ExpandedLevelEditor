import os
import bpy
import re
import math
import xml.etree.cElementTree as ET
from bpy.props import StringProperty, BoolProperty
from bpy.types import Operator
from mathutils import Matrix, Vector

# If 'False', all objects will be exported, if 'True', only objects that are selected will be exported.
export_selected = False

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
        mesh_files = {}
        used_names = set()

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

                if obj.hide_get():
                    continue

                if export_selected and obj not in prev_selected:
                    continue 

                if len(obj.data.uv_layers) < 1:
                    continue

                mesh_name = fix_filename(obj.data.name)
                objects.append(obj)

                mesh_key = f"{remove_suffix(mesh_name)}:{len(obj.data.vertices)}"
                if mesh_key in mesh_files:
                    exported_meshes[obj.name] = mesh_files[mesh_key]
                    continue

                new_name = mesh_name
                count = 1
                while new_name.lower() in used_names:
                    new_name = f"{mesh_name}_{count}"
                    count += 1
                used_names.add(new_name.lower())
                
                mesh_files[mesh_key] = new_name
                exported_meshes[obj.name] = new_name

                exported_obj = obj.copy()
                exported_obj.data = obj.data.copy()
                exported_obj.parent = None
                exported_obj.matrix_world = Matrix.Identity(4)
                
                if not exported_obj.name.endswith(":lod0"):
                    # so that frosty can import the objs
                    exported_obj.name += ":lod0"

                context.collection.objects.link(exported_obj)

                exported_obj.select_set(True)
                context.view_layer.objects.active = exported_obj

                fbx_path = os.path.join(self.directory, "Meshes", mesh_name + ".fbx")
                obj_path = os.path.join(self.directory, "Meshes", mesh_name + "_Collision.obj")

                if not os.path.exists(fbx_path):
                    bpy.ops.export_scene.fbx(
                        filepath=fbx_path, 
                        use_selection=True, 
                        global_scale=0.01, 
                        use_triangles=True, 
                        use_tspace=True)

                if not os.path.exists(obj_path):
                    bpy.ops.wm.obj_export(
                        filepath=obj_path, 
                        export_selected_objects=True, 
                        export_materials=False, 
                        export_normals=False,
                        export_uv=False)

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
            x_element.text = str(vec[0])
            y_element = ET.SubElement(parent, "Y")
            y_element.text = str(vec[1])
            z_element = ET.SubElement(parent, "Z")
            z_element.text = str(vec[2])

        def write_quaternion(parent, q):
            x_element = ET.SubElement(parent, "X")
            x_element.text = str(q[0])
            y_element = ET.SubElement(parent, "Y")
            y_element.text = str(q[1])
            z_element = ET.SubElement(parent, "Z")
            z_element.text = str(q[2])
            w_element = ET.SubElement(parent, "W")
            w_element.text = str(q[3])

        def write_transform(parent, transform):
            location = transform.translation.copy()
            rotation = transform.to_quaternion().normalized()
            scale = transform.to_scale()

            location_element = ET.SubElement(parent, "Location")
            write_vec3(location_element, (location.x, location.y, location.z))
            rotation_element = ET.SubElement(parent, "Quaternion")
            write_quaternion(rotation_element, (rotation.x, rotation.y, rotation.z, rotation.w))
            scale_element = ET.SubElement(parent, "Scale")
            write_vec3(scale_element, (scale.x, scale.y, scale.z))

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
                    mat = obj.material_slots[0].material
                    if mat is not None:
                        mat_name = mat.name

                obj_element = ET.SubElement(root, "Object")
                name_element = ET.SubElement(obj_element, "Name")
                name_element.text = fix_filename(obj.name)
                mesh_element = ET.SubElement(obj_element, "Mesh")
                mesh_element.text = exported_meshes[obj.name]
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

                bsdf = mat.node_tree.nodes["Principled BSDF"]
                base_color = bsdf.inputs["Base Color"]
                tint = base_color.default_value

                if base_color.is_linked:
                    new_tint = (1, 1, 1)

                    mix = base_color.links[0].from_node
                    if mix.type == "MIX" and mix.data_type == "RGBA":
                        tint_input = mix.inputs[7]

                        if not tint_input.is_linked:
                            new_tint = tint_input.default_value

                    if new_tint is not (1, 1, 1):
                        tint = new_tint

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
                    if image.packed_file:
                        textures_path = os.path.join(self.directory, "Textures")
                        os.makedirs(textures_path, exist_ok=True)

                        name = fix_filename(image.name)
                        if not os.path.splitext(name)[1]:
                            name += "." + image.file_format.lower()

                        path = os.path.join(textures_path, name)
                        with open(path, "wb") as f:
                            f.write(image.packed_file.data)

                        texture_path = path

                    texture_type = ""
                    if base_color.is_linked and node == base_color.links[0].from_node:
                        texture_type = "Color"

                    texture_element = ET.SubElement(textures_element, "Texture")

                    path_element = ET.SubElement(texture_element, "Path")
                    path_element.text = texture_path
                    type_element = ET.SubElement(texture_element, "Type")
                    type_element.text = texture_type

                tint_element = ET.SubElement(material_element, "Tint")
                write_vec3(tint_element, Vector((tint[0], tint[1], tint[2])))

            tree = ET.ElementTree(root)
            ET.indent(tree, space="    ")
            tree.write(xml_path)

        def export_lights(xml_path):
            root = ET.Element("Lights")

            for obj in bpy.data.objects:
                if obj.type != "LIGHT":
                    continue

                light = obj.data

                if light.type == "AREA":
                    continue

                light_object = bpy.data.objects[light.name]
                
                light_element = ET.SubElement(root, "Light")

                name_element = ET.SubElement(light_element, "Name")
                name_element.text = light_object.name
                type_element = ET.SubElement(light_element, "Type")
                type_element.text = light.type

                transform_element = ET.SubElement(light_element, "Transform")
                write_transform(transform_element, light_object.matrix_world)

                color_element = ET.SubElement(light_element, "Color")
                color_element.text = write_vec3(color_element, (light.color.r, light.color.g, light.color.b))
                intensity_element = ET.SubElement(light_element, "Intensity")
                intensity_element.text = str(light.energy)

                if light.type == "SPOT":
                    outer_angle_element = ET.SubElement(light_element, "OuterAngle")
                    outer_angle_element.text = str(math.degrees(light.spot_size))
                    inner_angle_element = ET.SubElement(light_element, "InnerAngle")
                    inner_angle_element.text = str(math.degrees(light.spot_size) * (1.0 - light.spot_blend))
                    
            tree = ET.ElementTree(root)
            ET.indent(tree, space="    ")
            tree.write(xml_path)

        obj_xml_path = os.path.join(self.directory, "Objects.xml")
        materials_xml_path = os.path.join(self.directory, "Materials.xml")
        lights_xml_path = os.path.join(self.directory, "Lights.xml")
        
        export_objects(obj_xml_path)
        export_materials(materials_xml_path)
        export_lights(lights_xml_path)
            
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