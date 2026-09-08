# All of this apart from material importing is made by Sprett (@sprettwashere on discord)

# Level importer for PvZ GW1

import bpy
import os
import xml.etree.ElementTree as ET
import math
import mathutils
import sys
import gc
import re
from bpy.props import StringProperty, BoolProperty
from bpy.types import Operator
from mathutils import Matrix, Vector, Quaternion
from pathlib import Path

def add_root_element(filename):
    try:
        ET.parse(filename).getroot()
    except ET.ParseError:
        with open(filename, 'r', encoding='utf-8') as f:
            text = f.read()
        text = '<root>\n' + text + '\n</root>'
        with open(filename, 'w', encoding='utf-8') as f:
            f.write(text)

def comma_float(text):
    try:
        return float(text.replace(',', '.'))
    except:
        return 0.0

def progress(i,t,label):
    print(f"\r[{label}] {i}/{t}", end='')
    sys.stdout.flush()

def duplicate_hierarchy_fast(source_root, collection):

    originals = [source_root] + list(source_root.children_recursive)
    mapping = {}

    for obj in originals:

        new = obj.copy()

        if obj.data:
            new.data = obj.data

        collection.objects.link(new)

        new.matrix_world = obj.matrix_world.copy()

        mapping[obj] = new

    for old, new in mapping.items():
        if old.parent in mapping:
            new.parent = mapping[old.parent]

    return mapping[source_root]


class ImportFolderOperator(Operator):
    bl_idname = "import_scene.level_folder"
    bl_label = "Select Level Folder"

    directory: StringProperty(
        name="Outdir Path",
        description="Select the level folder"
    )

    filter_folder: BoolProperty(
        default=True,
        options={"HIDDEN"}
    )

    terrain_ext = ".obj"
    light_ext = ".xml"

    def execute(self, context):
        terrain_folder = os.path.join(os.path.dirname(self.directory), "TerrainChunks")
        lights_folder = os.path.join(os.path.dirname(self.directory), "Lights")
        meshes_folder = os.path.join(os.path.dirname(self.directory), "Meshes")
        textures_folder = os.path.join(os.path.dirname(self.directory), "Textures")

        # Terrain Chunk importing
        terrain_collection = bpy.data.collections.new(name="Terrain")
        bpy.context.scene.collection.children.link(terrain_collection)
        
        if not terrain_folder:
            self.report({'ERROR'}, "No folder selected")
            return {'CANCELLED'}

        imported_objects = []

        terrain_decimation = 0.05

        root = ET.parse(os.path.join(meshes_folder, f"{Path(self.directory).name}.xml")).getroot()
        for element in root.iter():
            settings = element.find('Settings')

            if settings is not None:
                terrain_decimation = float(settings.findtext('TerrainDecimation'))
                break

        for filename in os.listdir(terrain_folder):
            if filename.lower().endswith(".obj"):
                filepath = os.path.join(terrain_folder, filename)
                
                with open(filepath, "r") as file:
                    content = file.read()
                
                fixed_content = content.replace(",", ".")
                
                with open(filepath, "w") as file:
                    file.write(fixed_content)
                
                bpy.ops.wm.obj_import(filepath=filepath)
                
                for obj in bpy.context.selected_objects:
                    for col in obj.users_collection:
                        col.objects.unlink(obj)
                    terrain_collection.objects.link(obj)
                
                bpy.context.view_layer.objects.active = obj
                obj.select_set(True)
                bpy.ops.object.mode_set(mode='EDIT')
                bpy.ops.mesh.customdata_custom_splitnormals_clear()
                bpy.ops.object.mode_set(mode='OBJECT')
                obj.select_set(False)

                if terrain_decimation < 1 or terrain_decimation > 0:
                    decimate = obj.modifiers.new(name="Decimate", type="DECIMATE")
                    decimate.ratio = terrain_decimation
                    bpy.ops.object.modifier_apply(modifier=decimate.name)
                    
                imported_objects.extend(context.selected_objects)
                self.report({'INFO'}, f"Imported: {filename}")

        bpy.data.orphans_purge(do_recursive=True)
        gc.collect()
        
        self.report({'INFO'}, f"Finished importing terrain from {terrain_folder}")
        
        # Light importing
        for filename in os.listdir(lights_folder):
            xml_file_path = os.path.join(lights_folder, filename)

            def load_xml_with_fallback(filename):
                try:
                    tree = ET.parse(filename)
                    print("XML root element found")
                    return tree.getroot()
                except ET.ParseError:
                    print("wrapping XML with temporary root...")
                    with open(filename, 'r', encoding='utf-8') as f:
                        text = f.read()
                    text = "<root>\n" + text + "\n</root>"
                    return ET.fromstring(text)

            root = load_xml_with_fallback(xml_file_path)

            def parse_float(s):
                return float(s.replace(',', '.'))

            def rotation_from_linear_transform(lt_node):
                def vec3_swap(node_name):
                    node = lt_node.find(f'{node_name}/Vec3')
                    return mathutils.Vector((
                        parse_float(node.find('x').text),
                        parse_float(node.find('z').text),
                        parse_float(node.find('y').text)
                    ))

                r = vec3_swap('right')
                u = vec3_swap('up')
                f = vec3_swap('forward')

                rot_matrix = mathutils.Matrix((r, u, f)).transposed()
                return rot_matrix.to_euler()

            def get_location(light_data):
                trans_node = light_data.find('Transform/LinearTransform/trans/Vec3')
                x = parse_float(trans_node.find('x').text)
                y = parse_float(trans_node.find('z').text)
                z = parse_float(trans_node.find('y').text)
                return (x, -y, z)

            def get_color(light_data):
                color_node = light_data.find('Color/Vec3')
                r = parse_float(color_node.find('x').text)
                g = parse_float(color_node.find('y').text)
                b = parse_float(color_node.find('z').text)
                return (r, g, b)
            
            light_multiplier = 8

            # Place PBR Sphere Light
            for light_data in root.findall('.//PbrSphereLightEntityData'):

                enabled = light_data.find('Enabled')
                if enabled is not None and enabled.text.lower() != 'true':
                    continue

                guid = light_data.get('Guid')

                light = bpy.data.lights.new(name=f"PbrSphere_{guid}", type='POINT')
                light.color = get_color(light_data)

                intensity_node = light_data.find('Intensity')

                energy = float(intensity_node.text) if intensity_node is not None else 1.0
                light.energy = energy * light_multiplier

                light_obj = bpy.data.objects.new(light.name, light)
                bpy.context.collection.objects.link(light_obj)
                light_obj.location = get_location(light_data)


            # Place Point Light
            for light_data in root.findall('.//PointLightEntityData'):

                enabled = light_data.find('Enabled')
                if enabled is not None and enabled.text.lower() != 'true':
                    continue

                guid = light_data.get('Guid')

                light = bpy.data.lights.new(name=f"Point_{guid}", type='POINT')
                light.color = get_color(light_data)

                intensity_node = light_data.find('Intensity')

                energy = float(intensity_node.text) if intensity_node is not None else 1.0
                light.energy = energy * light_multiplier

                radius_node = light_data.find('Radius')
                if radius_node is not None:
                    try:
                        light.shadow_soft_size = parse_float(radius_node.text)
                    except:
                        pass

                light_obj = bpy.data.objects.new(light.name, light)
                bpy.context.collection.objects.link(light_obj)
                light_obj.location = get_location(light_data)


            #Place PBR Spotlight
            for light_data in root.findall('.//PbrSpotLightEntityData'):

                enabled = light_data.find('Enabled')
                if enabled is not None and enabled.text.lower() != 'true':
                    continue

                guid = light_data.get('Guid')

                light = bpy.data.lights.new(name=f"Spot_{guid}", type='SPOT')
                light.color = get_color(light_data)

                intensity_node = light_data.find('Intensity')

                energy = float(intensity_node.text) if intensity_node is not None else 1.0
                light.energy = energy * light_multiplier

                inner_angle_node = light_data.find('InnerAngle')
                outer_angle_node = light_data.find('OuterAngle')

                if inner_angle_node is not None and outer_angle_node is not None:
                    inner_deg = parse_float(inner_angle_node.text)
                    outer_deg = parse_float(outer_angle_node.text)
                    light.spot_size = math.radians(outer_deg)
                    light.spot_blend = max(0.0, min(1.0, 1 - inner_deg / outer_deg))

                light_obj = bpy.data.objects.new(light.name, light)
                bpy.context.collection.objects.link(light_obj)

                light_obj.location = get_location(light_data)

                lt_node = light_data.find('Transform/LinearTransform')
                if lt_node is not None:
                    light_obj.rotation_euler = rotation_from_linear_transform(lt_node)

            
            # Place Spotlight
            for light_data in root.findall('.//SpotLightEntityData'):

                enabled = light_data.find('Enabled')
                if enabled is not None and enabled.text.lower() != 'true':
                    continue

                guid = light_data.get('Guid')

                light = bpy.data.lights.new(name=f"SpotEntity_{guid}", type='SPOT')
                light.color = get_color(light_data)

                intensity_node = light_data.find('Intensity')

                energy = float(intensity_node.text) if intensity_node is not None else 1.0
                light.energy = energy * light_multiplier

                # Cone angles
                inner_angle_node = light_data.find('ConeInnerAngle')
                outer_angle_node = light_data.find('ConeOuterAngle')

                if inner_angle_node is not None and outer_angle_node is not None:
                    inner_deg = parse_float(inner_angle_node.text)
                    outer_deg = parse_float(outer_angle_node.text)

                    light.spot_size = math.radians(outer_deg)

                    if outer_deg != 0:
                        light.spot_blend = max(0.0, min(1.0, 1 - inner_deg / outer_deg))

                radius_node = light_data.find('Radius')
                if radius_node is not None:
                    try:
                        light.shadow_soft_size = parse_float(radius_node.text)
                    except:
                        pass

                light_obj = bpy.data.objects.new(light.name, light)
                bpy.context.collection.objects.link(light_obj)

                light_obj.location = get_location(light_data)

                lt_node = light_data.find('Transform/LinearTransform')
                if lt_node is not None:
                    light_obj.rotation_euler = rotation_from_linear_transform(lt_node)
            self.report({'INFO'}, f"Imported lights from {filename}")
        
        self.report({'INFO'}, f"Finished importing lights from {self.directory}")

        texture_cache = {}

        def load_texture(file_path):
            if file_path in texture_cache:
                texture = bpy.data.images.get(texture_cache[file_path])
                if texture:
                    return texture
                else:
                    del texture_cache[file_path]
            
            texture = bpy.data.images.load(file_path, check_existing=True)
            texture_cache[file_path] = texture.name
            return texture

        # Mesh importing
        def create_meshes(xml_file_path, material_xml_path):
            add_root_element(xml_file_path)

            Model_Name = bpy.path.display_name_from_filepath(xml_file_path)
            Working_Folder = os.path.dirname(xml_file_path)


            root = ET.parse(xml_file_path).getroot()
            material_root = ET.parse(material_xml_path).getroot()

            Obj_Names = []
            Mesh_Names = []
            Mesh_Names_Dic = {}
            MatTemp = []

            materials = {}

            MatImported = []
            for element in root.iter():

                settings = element.find('Settings')

                if settings is not None:
                    transparent_materials = settings.findtext('UseAlpha') == "True"

                blueprint = element.findtext('Blueprint')
                transform = element.find('Transform/LinearTransform')
                
                if blueprint and transform is not None:
                    x1 = comma_float(transform.findtext('right/Vec3/x','0'))
                    y1 = comma_float(transform.findtext('right/Vec3/y','0'))
                    z1 = comma_float(transform.findtext('right/Vec3/z','0'))
                    x2 = comma_float(transform.findtext('up/Vec3/x','0'))
                    y2 = comma_float(transform.findtext('up/Vec3/y','0'))
                    z2 = comma_float(transform.findtext('up/Vec3/z','0'))
                    x3 = comma_float(transform.findtext('forward/Vec3/x','0'))
                    y3 = comma_float(transform.findtext('forward/Vec3/y','0'))
                    z3 = comma_float(transform.findtext('forward/Vec3/z','0'))
                    tx = comma_float(transform.findtext('trans/Vec3/x','0'))
                    ty = comma_float(transform.findtext('trans/Vec3/y','0'))
                    tz = comma_float(transform.findtext('trans/Vec3/z','0'))

                    mat = Matrix(((x1,y1,z1,tx),
                                  (x2,y2,z2,ty),
                                  (x3,y3,z3,tz),
                                  (0,0,0,1)))
                    
                    imported = (blueprint, mat)
                    if imported not in MatImported:
                        Obj_Names.append(blueprint.rpartition('/')[2])
                        MatImported.append(imported)
                        MatTemp.append(mat)
                    
                        sections = element.find('Sections')
                        if sections is not None:
                            for index, section in enumerate(sections.findall('Section')):
                                full_name = f"{blueprint.rpartition('/')[2]}:{index}"

                                Mesh_Names_Dic[full_name] = section.findtext('Name')
                                Mesh_Names.append(full_name)


            Asset_Pool = bpy.data.objects.get("Asset_Pool")
            if not Asset_Pool:
                Asset_Pool = bpy.data.objects.new("Asset_Pool",None)
                context.collection.objects.link(Asset_Pool)

            Asset_Pool_List = [c.name for c in Asset_Pool.children]

            Grand_Parent_Empty = bpy.data.objects.new(Model_Name,None)
            context.collection.objects.link(Grand_Parent_Empty)

            for outer_material in material_root.findall("Material"):
                outer_name = outer_material.findtext("Name").rpartition('/')[2]

                inner_materials = {}
                for inner_material in outer_material.findall("Material"):
                    material_name = inner_material.findtext("Name")

                    vector_params = []
                    texture_params = {}
                    
                    for vector_param in inner_material.findall("./VectorParameters/Parameter"):
                        type = vector_param.findtext("ParameterType")

                        x = vector_param.findtext("Value/Vec4/x")
                        y = vector_param.findtext("Value/Vec4/y")
                        z = vector_param.findtext("Value/Vec4/z")

                        value = f"{x},{y},{z}"
                        vector_params.append([vector_param.findtext("ParameterName"), type, value])

                    for texture_param in inner_material.findall("./TextureParameters/Parameter"):
                        name = texture_param.findtext("ParameterName")
                        value = texture_param.findtext("Value")

                        # for param names with prefixes like 'Material1_'
                        names = ["Diffuse", "Normal", "PSA", "Specular_Masks"]

                        for x in names:
                            if x in name:
                                name = x
                                break

                        if name not in texture_params:
                            texture_params[name] = value

                    if material_name not in inner_materials:
                        inner_materials[material_name] = [vector_params, texture_params]
                
                materials[outer_name] = inner_materials

            unique_assets = list(set(Obj_Names))
            obj_pool = []

            for i, Obj_Name in enumerate(unique_assets,1):

                progress(i,len(unique_assets),"FBX")

                if i % 20 == 0:
                    used_names = {image_name for image_name in texture_cache.values()}
                    for image in bpy.data.images:
                        if image.name not in used_names:
                            image.gl_free()
                    
                    bpy.data.orphans_purge(do_recursive=True)
                    gc.collect()

                if Obj_Name not in Asset_Pool_List:
                    obj_material = materials.get(Obj_Name.lower() + "_Mesh") 

                    FBX_Path = Path(Working_Folder)/f"{Obj_Name}_mesh.fbx"

                    if FBX_Path.exists():
                        bpy.ops.import_scene.fbx(
                            filepath=str(FBX_Path),
                            use_anim=False,
                            use_prepost_rot=True,
                            use_manual_orientation=False,
                            bake_space_transform=False,
                            axis_forward='-Z',
                            axis_up='Y'
                        )

                        imported = list(bpy.context.selected_objects)
                        
                        def remove_suffix(name):
                            return re.sub(r'\.\d+$', '', name)
                        
                        mesh_by_name = {}

                        for obj_index, obj in enumerate(imported):
                            obj_pool.append(obj)
                            if obj.type == "MESH":
                                obj_name = obj.name if "lambert" not in obj.name else f"{Obj_Name}:{obj_index}"
                                new_name = remove_suffix(obj_name)
                                mesh_by_name[new_name] = obj

                        names = []
                        for n in Mesh_Names:
                            first = n.split(":")[0]
                            if first == Obj_Name:
                                names.append(n)

                        for name in names:
                            mesh_name = Mesh_Names_Dic.get(name)

                            if mesh_name is None:
                                continue
                            
                            if "lambert" in name:
                                obj = mesh_by_name.get(name)
                            else:
                                obj = mesh_by_name.get(mesh_name)
                            
                            if obj is None:
                                print(f"Skipping {name}, mesh_name: {mesh_name}, Obj_Name: {Obj_Name}. mesh_by_name:\n{mesh_by_name}")
                                continue
                            
                            material_name = f"{Obj_Name}:{mesh_name}"

                            if material_name in bpy.data.materials:
                                obj.data.materials.append(bpy.data.materials[material_name])
                            else:
                                mesh_material = obj_material.get(mesh_name)
                                if mesh_material:
                                    vector_params = mesh_material[0]
                                    texture_params = mesh_material[1]

                                    diffuse = texture_params.get("Diffuse")
                                    psa = texture_params.get("PSA")
                                    normal = texture_params.get("Normal")

                                    if psa is None:
                                        psa = texture_params.get("Specular_Masks")

                                    psa_path = os.path.join(textures_folder, f"{psa}.png")
                                    color_path = os.path.join(textures_folder, f"{diffuse}.png")
                                    normal_path = os.path.join(textures_folder, f"{normal}.png")

                                    material = bpy.data.materials.new(name=material_name)
                                    material.use_nodes = True

                                    tint_r = 1
                                    tint_g = 1
                                    tint_b = 1

                                    use_vector_params = False
                                    for param in vector_params:
                                        param_name = param[0]
                                        param_type = param[1]
                                        param_value = param[2]

                                        if ("Tint_Color" in param_name or "Tint_Colour" in param_name) and param_type == "ShaderParameterType_Color":
                                            use_vector_params = True

                                            rgb = param_value.split(",")

                                            tint_r *= float(rgb[0])
                                            tint_g *= float(rgb[1])
                                            tint_b *= float(rgb[2])

                                    bsdf = material.node_tree.nodes["Principled BSDF"]
                                    bsdf.location = (700, 200)

                                    output_node = material.node_tree.nodes["Material Output"]
                                    output_node.location = (1300, 200)

                                    psa_texture_node = material.node_tree.nodes.new("ShaderNodeTexImage")
                                    psa_texture_node.location = (-800, 100)

                                    psa_seperate_node = material.node_tree.nodes.new("ShaderNodeSeparateColor")
                                    psa_seperate_node.location = (-400, 100)

                                    invert_smoothness_node = material.node_tree.nodes.new("ShaderNodeInvert")
                                    invert_smoothness_node.location = (-100, 50)

                                    color_texture_node = material.node_tree.nodes.new("ShaderNodeTexImage")
                                    color_texture_node.location = (-800, 450)

                                    tint_color_node = material.node_tree.nodes.new("ShaderNodeMix")
                                    tint_color_node.data_type = "RGBA"
                                    tint_color_node.blend_type = "MULTIPLY"
                                    tint_color_node.inputs["Factor"].default_value = 1.0
                                    tint_color_node.inputs["B"].default_value = (tint_r, tint_g, tint_b, 1.0)
                                    tint_color_node.location = (-400, 350)

                                    ao_mix_node = material.node_tree.nodes.new("ShaderNodeMixShader")
                                    ao_mix_node.location = (1000, 400)

                                    normal_texture_node = material.node_tree.nodes.new("ShaderNodeTexImage")
                                    normal_texture_node.location = (-800, -250)

                                    normal_map_node = material.node_tree.nodes.new("ShaderNodeNormalMap")
                                    normal_map_node.inputs["Strength"].default_value = -1.0
                                    normal_map_node.location = (200, -250)

                                    if os.path.exists(psa_path) and psa:
                                        psa_texture_node.image = load_texture(psa_path)
                                        psa_texture_node.image.colorspace_settings.name = "Non-Color"

                                        material.node_tree.links.new(psa_texture_node.outputs["Color"], psa_seperate_node.inputs["Color"])
                                        material.node_tree.links.new(psa_seperate_node.outputs["Red"], bsdf.inputs["Specular IOR Level"])
                                        material.node_tree.links.new(psa_seperate_node.outputs["Green"], invert_smoothness_node.inputs["Color"])
                                        material.node_tree.links.new(psa_seperate_node.outputs["Blue"], ao_mix_node.inputs["Factor"])
                                        material.node_tree.links.new(invert_smoothness_node.outputs["Color"], bsdf.inputs["Roughness"])

                                        # the ao (ambient occlusion) in psa textures makes the material black, so it's just removed for now
                                        #material.node_tree.links.new(ao_mix_node.outputs["Shader"], output_node.inputs["Surface"])

                                    if os.path.exists(color_path) and diffuse:
                                        color_texture_node.image = load_texture(color_path)

                                        image_source = tint_color_node.outputs["Result"] if use_vector_params else color_texture_node.outputs["Color"]
                                        material.node_tree.links.new(image_source, bsdf.inputs["Base Color"])
                                        material.node_tree.links.new(bsdf.outputs["BSDF"], ao_mix_node.inputs["Shader_001"])

                                        if transparent_materials:
                                            material.node_tree.links.new(color_texture_node.outputs["Alpha"], bsdf.inputs["Alpha"])
                                        else:
                                            color_texture_node.image.alpha_mode = "NONE"
                                    else:
                                        # use the tint color directly
                                        bsdf.inputs["Base Color"].default_value = (tint_r, tint_g, tint_b, 1.0)

                                    if os.path.exists(normal_path) and normal:
                                        normal_texture_node.image = load_texture(normal_path)
                                        normal_texture_node.image.colorspace_settings.name = "Non-Color"

                                        material.node_tree.links.new(normal_texture_node.outputs["Color"], normal_map_node.inputs["Color"])
                                        material.node_tree.links.new(normal_map_node.outputs["Normal"], bsdf.inputs["Normal"])
                                    
                                    obj.data.materials.append(material)

                        parent_empty = bpy.data.objects.new(Obj_Name,None)
                        context.collection.objects.link(parent_empty)

                        for obj in imported:
                            if obj.parent is None:
                                obj.parent = parent_empty
                        
                        parent_empty.parent = Asset_Pool
                        Asset_Pool_List.append(Obj_Name)

            total = len(Obj_Names)

            for i,(Obj_Name,mat) in enumerate(zip(Obj_Names,MatTemp),1):

                progress(i,total,"Duplicate")

                if Obj_Name in Asset_Pool_List:

                    source = bpy.data.objects[Obj_Name]

                    dup_parent = duplicate_hierarchy_fast(source,context.collection)

                    dup_parent.parent = Grand_Parent_Empty

                    MM_Loc, MM_Rot, MM_Scale = mat.decompose()
                    MM_Rot = mat.to_quaternion()

                    rw , rx, ry, rz = MM_Rot.w, MM_Rot.x, MM_Rot.y, MM_Rot.z
                    lx, ly, lz = MM_Loc[0], MM_Loc[1], MM_Loc[2]
                    sx, sy, sz = MM_Scale[0], MM_Scale[1], MM_Scale[2]

                    MM_Scale_New = Vector(( sx, sz, sy ))
                    MM_Rot_New = Quaternion(( rw, -rx, rz, -ry ))
                    MM_Loc_New = Vector(( lx, -lz, ly ))

                    dup_parent.scale = MM_Scale_New
                    dup_parent.rotation_mode = 'QUATERNION'
                    dup_parent.rotation_quaternion = MM_Rot_New
                    dup_parent.location = MM_Loc_New

            bpy.ops.object.select_all(action="DESELECT")
            
            print(f"\nDeleting {len(obj_pool)} objects from the object pool...")
            for obj in obj_pool:
                obj.select_set(True)
            bpy.ops.object.delete()
        
        create_meshes(os.path.join(meshes_folder, f"{Path(self.directory).name}.xml"), os.path.join(self.directory, "Materials.xml"))

        self.report({'INFO'}, f"Finished importing meshes and textures from {self.directory}")

        self.report({'INFO'}, f"Finished importing {Path(self.directory).name}")
        return {'FINISHED'}
    
    def invoke(self, context, event):
        context.window_manager.fileselect_add(self)
        return {'RUNNING_MODAL'}


def menu_func(self, context):
    self.layout.operator(
        ImportFolderOperator.bl_idname,
        text="Import Level Folder"
    )


def register():
    bpy.utils.register_class(ImportFolderOperator)
    bpy.types.TOPBAR_MT_file_import.append(menu_func)

    bpy.ops.import_scene.level_folder('INVOKE_DEFAULT')


def unregister():
    bpy.types.TOPBAR_MT_file_import.remove(menu_func)
    bpy.utils.unregister_class(ImportFolderOperator)


if __name__ == "__main__":
    register()