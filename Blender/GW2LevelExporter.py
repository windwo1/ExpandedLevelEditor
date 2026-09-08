import os
import bpy
import re
import xml.etree.cElementTree as ET
from bpy.props import StringProperty, BoolProperty
from bpy.types import Operator
from mathutils import Matrix

def remove_suffix(name):
    return re.sub(r'\.\d+$', '', name)

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
        for obj in bpy.data.objects:
            if obj.type != "MESH":
                continue

            bpy.ops.object.select_all(action="DESELECT")
            
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

            # will export duplicate meshes but idk of a good way to deduplicate them (names wouldn't work because common names like 'lambert' or 'Metal')
            path = os.path.join(self.directory, "Meshes", obj.name + ".fbx")

            if not os.path.exists(path):
                bpy.ops.export_scene.fbx(filepath=path, use_selection=True, global_scale=0.01, use_triangles=True, use_tspace=True)

            bpy.data.objects.remove(exported_obj, do_unlink=True)
            objects.append(obj)

        def export_objects(xml_path):
            root = ET.Element("Objects")

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

            for obj in objects:
                mat_name = ""
                if len(obj.material_slots) > 0:
                    mat_name = obj.material_slots[0].material.name

                obj_element = ET.SubElement(root, "Object")
                name_element = ET.SubElement(obj_element, "Name")
                name_element.text = obj.name
                mat_element = ET.SubElement(obj_element, "Material")
                mat_element.text = mat_name

                location = obj.matrix_world.translation.copy()
                rotation = obj.matrix_world.to_quaternion().normalized()
                scale = obj.matrix_world.to_scale()

                transform_element = ET.SubElement(obj_element, "Transform")

                location_element = ET.SubElement(transform_element, "Location")
                write_vec3(location_element, location)
                rotation_element = ET.SubElement(transform_element, "Quaternion")
                write_quaternion(rotation_element, rotation)
                scale_element = ET.SubElement(transform_element, "Scale")
                write_vec3(scale_element, scale)

            tree = ET.ElementTree(root)
            ET.indent(tree, space="    ")
            tree.write(xml_path)
        
        def export_materials(xml_path):
            root = ET.Element("Materials")

            for mat in bpy.data.materials:
                material_element = ET.SubElement(root, "Material")

                name_element = ET.SubElement(material_element, "Name")
                name_element.text = mat.name

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


        obj_xml_path = os.path.join(self.directory, "Objects.xml")
        materials_xml_path = os.path.join(self.directory, "Materials.xml")
        
        export_objects(obj_xml_path)
        export_materials(materials_xml_path)
            
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