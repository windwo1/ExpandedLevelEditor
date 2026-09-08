using Frosty.Controls;
using Frosty.Core;
using Frosty.Core.Controls;
using Frosty.Core.Viewport;
using Frosty.Core.Windows;
using Frosty.Hash;
using FrostySdk;
using FrostySdk.Attributes;
using FrostySdk.Ebx;
using FrostySdk.IO;
using FrostySdk.Managers;
using FrostySdk.Resources;
using LevelEditorPlugin.Entities;
using LevelEditorPlugin.Layers;
using LevelEditorPlugin.Managers;
using LevelEditorPlugin.Properties;
using MeshSetPlugin;
using SharpDX;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using TexturePlugin;
using BundleType = FrostySdk.Managers.BundleType;
using D3D11 = SharpDX.Direct3D11;
using MeshMaterial = FrostySdk.Ebx.MeshMaterial;
using MeshSet = MeshSetPlugin.Resources.MeshSet;
using TextureType = FrostySdk.Resources.TextureType;

namespace LevelEditorPlugin.Editors.Importers
{
    public class LevelImporter
    {
        private class LevelImportSettings
        {
            [DisplayName("Overwrite Level")]
            public bool OverwriteLevel { get; set; } = true;
            [DisplayName("Object Offset")]
            public Vec3 ObjectOffset { get; set; }
        }
        
        private class GameDefaults
        {
            public EbxAssetEntry Shader { get; set; }
            public EbxAssetEntry ASMTexture { get; set; }
            public EbxAssetEntry ColorTexture { get; set; }
            public EbxAssetEntry NormalTexture { get; set; }
            public EbxAssetEntry ETTTexture { get; set; }
        }

        private class ObjectInfo
        {
            public string Name { get; set; }
            public Matrix Transform { get; set; }
            public MaterialInfo Material { get; set; }
        }

        private class MaterialInfo
        {
            public string Name { get; set; }
            public List<string> Textures { get; set; }
        }

        private LevelImportSettings importSettings;

        private EbxAssetEntry levelEntry;
        private EbxAsset levelAsset;
        private ReferenceObject world;

        private GameDefaults gameDefaults;

        private static SkinnedMeshAsset skinnedSample;
        private static RigidMeshAsset rigidSample;
        private static CompositeMeshAsset compositeSample;
        private static TextureAsset textureSample;

        private const int LodCount = 1;

        public LevelImporter(ref SceneLayer rootLayer, LevelEditor editor, ReferenceObject editingWorld)
        {
            importSettings = new LevelImportSettings
            {
                OverwriteLevel = Config.Get<bool>("OverwriteLevel", true),
                ObjectOffset = Config.Get<Vec3>("ObjectOffset", new Vec3())
            };

            if (FrostyImportExportBox.Show("Level Import Settings", FrostyImportExportType.Export, importSettings) == MessageBoxResult.OK)
            {
                FrostyOpenFileDialog ofd = new FrostyOpenFileDialog("Open Level Folder", "All files (*.*)|*.*", "Level");

                if (ofd.ShowDialog())
                {
                    string levelPath = Path.GetDirectoryName(ofd.FileName);

                    Config.Add("OverwriteLevel", importSettings.OverwriteLevel);
                    Config.Add("ObjectOffset", importSettings.ObjectOffset);
                    Config.Save();

                    levelEntry = editor.AssetEntry as EbxAssetEntry;
                    levelAsset = editor.Asset;
                    world = editingWorld;

                    SceneLayer layer = rootLayer;
                    FrostyTaskWindow.Show("Importing Level", "", (task) =>
                    {
                        layer = ImportLevel(task, levelPath, layer, editor);
                    });

                    if (layer != null)
                    {
                        rootLayer = layer;
                    }
                }
            }
        }

        private SceneLayer ImportLevel(FrostyTaskWindow task, string levelPath, SceneLayer rootLayer, LevelEditor editor)
        {
            task.Update("Getting asset samples");

            GetSamples();
            gameDefaults = GetDefaults();

            var layer = editor.AddedLayer;
            var sceneLayer = editor.AddedSceneLayer;

            SceneLayer root = null;

            if (importSettings.OverwriteLevel)
            {
                task.Update("Clearing level");

                rootLayer.ClearLayers();

                var levelData = levelAsset.RootObject as LevelData;

                foreach (var worldPartRef in levelData.Objects.Where(o => o.Internal is WorldPartReferenceObjectData))
                {
                    (worldPartRef.Internal as WorldPartReferenceObjectData).Blueprint = new PointerRef();
                }
                foreach (var subWorldRef in levelData.Objects.Where(o => o.Internal is SubWorldReferenceObjectData))
                {
                    (subWorldRef.Internal as SubWorldReferenceObjectData).Blueprint = new PointerRef();
                    (subWorldRef.Internal as SubWorldReferenceObjectData).BundleName = "";
                }

                string layerName = "layer0_leveleditor";

                var part = CreateAsset($"{levelEntry.Name}/{layerName}", TypeLibrary.GetType("WorldPartData"));
                var partAsset = App.AssetManager.GetEbx(part);
                (partAsset.RootObject as WorldPartData).Enabled = true;
                part.AddedBundles.AddRange(levelEntry.EnumerateBundles());

                var partRef = Utils.CreateEntityData(typeof(WorldPartReferenceObjectData), levelAsset) as WorldPartReferenceObjectData;
                partRef.LightmapResolutionScale = 1;
                partRef.CastSunShadowEnable = true;
                partRef.CastReflectionEnable = true;
                partRef.CastEnvmapEnable = true;
                partRef.Blueprint = CreateRef(part.Name, levelAsset);

                levelAsset.AddObject(partRef);

                App.AssetManager.ModifyEbx(levelEntry.Name, levelAsset);
                App.AssetManager.ModifyEbx(part.Name, partAsset);

                var partEntity = new WorldPartReferenceObject(partRef, world);
                world.AddEntity(partEntity);

                layer = part;
                sceneLayer = new SceneLayer(partEntity, layerName);
                rootLayer.AddLayer(sceneLayer);
            }

            string materialsXml = Path.Combine(levelPath, "Materials.xml");
            string objectsXml = Path.Combine(levelPath, "Objects.xml");

            var materials = new List<MaterialInfo>();
            var objects = new List<ObjectInfo>();

            task.Update("Reading Materials.xml");
            var materialDoc = new XmlDocument();
            materialDoc.Load(materialsXml);

            var materialsNode = materialDoc.FirstChild;
            foreach (XmlNode matNode in materialsNode.ChildNodes)
            {
                if (matNode.NodeType == XmlNodeType.Comment)
                    continue;

                var material = new MaterialInfo();
                material.Name = matNode.SelectSingleNode("Name").InnerText;

                material.Textures = new List<string>();
                foreach (XmlNode texNode in matNode.SelectSingleNode("Textures").ChildNodes)
                {
                    material.Textures.Add(texNode.InnerText);
                }

                materials.Add(material);
            }

            task.Update("Reading Objects.xml");
            var objectlDoc = new XmlDocument();
            objectlDoc.Load(objectsXml);

            var objectsNode = objectlDoc.FirstChild;
            foreach (XmlNode objNode in objectsNode.ChildNodes)
            {
                if (objNode.NodeType == XmlNodeType.Comment)
                    continue;

                var obj = new ObjectInfo();
                obj.Name = objNode.SelectSingleNode("Name").InnerText;

                string mat = objNode.SelectSingleNode("Material").InnerText;
                obj.Material = materials.Find(m => m.Name == mat);

                var transformNode = objNode.SelectSingleNode("Transform");

                Vector3 location;
                Quaternion quaternion;
                Vector3 scale;
                var lNode = transformNode.SelectSingleNode("Location");
                location = new Vector3(float.Parse(lNode.SelectSingleNode("X").InnerText),
                                       float.Parse(lNode.SelectSingleNode("Y").InnerText),
                                       float.Parse(lNode.SelectSingleNode("Z").InnerText));
                var qNode = transformNode.SelectSingleNode("Quaternion");
                quaternion = new Quaternion(float.Parse(qNode.SelectSingleNode("X").InnerText),
                                            float.Parse(qNode.SelectSingleNode("Y").InnerText),
                                            float.Parse(qNode.SelectSingleNode("Z").InnerText),
                                            float.Parse(qNode.SelectSingleNode("W").InnerText));
                var sNode = transformNode.SelectSingleNode("Scale");
                scale = new Vector3(float.Parse(sNode.SelectSingleNode("X").InnerText),
                                    float.Parse(sNode.SelectSingleNode("Y").InnerText),
                                    float.Parse(sNode.SelectSingleNode("Z").InnerText));

                obj.Transform = FromBlenderTransform(location, quaternion, scale);

                objects.Add(obj);
            }

            // @todo: light importing

            var entities = new List<Entities.Entity>();
            int count = 0;

            foreach (var obj in objects)
            {
                task.Update("Importing " + obj.Name, progress: ((double)count / objects.Count) * 100.0);

                // @todo: get mesh type from the export
                MeshAsset sample = rigidSample;

                //if (obj.Name == "flowerVaseA_mat1.001" || obj.Name == "Hub_Veg_RoseThrone_Rose.001")
                //    sample = compositeSample;

                var sampleEntry = App.AssetManager.GetEbxEntry(sample.Name);

                string meshAssetPath = $"_leveleditor/Meshes/{obj.Name}_Mesh";
                string blueprintAssetPath = $"_leveleditor/Meshes/{obj.Name}";

                if (App.AssetManager.GetEbxEntry(meshAssetPath) == null || App.AssetManager.GetEbxEntry(blueprintAssetPath) == null)
                {
                    var mesh = CreateMesh(meshAssetPath, TypeLibrary.GetType(sample.GetType().Name), sample);
                    var blueprint = CreateAsset(blueprintAssetPath, TypeLibrary.GetType("ObjectBlueprint"));

                    var blueprintEntry = App.AssetManager.GetEbxEntry(blueprint.Name);
                    var blueprintAsset = App.AssetManager.GetEbx(blueprint);
                    var meshEntry = App.AssetManager.GetEbxEntry(mesh.Name);
                    var meshAsset = App.AssetManager.GetEbx(mesh);

                    var objBlueprint = App.AssetManager.GetEbx(blueprint).RootObject as ObjectBlueprint;

                    ApplyObjectBlueprintDefaults(blueprintAsset, objBlueprint, mesh);

                    var dbEntry = MeshVariationDb.GetVariations(sampleEntry.Guid);
                    MeshVariation mv = null;
                    if (dbEntry != null)
                    {
                        mv = dbEntry.GetVariation(MeshVariationDbEntry.ROOT_VARIATION);
                    }

                    MeshVariationMaterial material = null;
                    foreach (var matRef in sample.Materials)
                    {
                        if (mv == null)
                            break;

                        var mat = matRef.Internal as MeshMaterial;

                        int idx = mv.Materials.FindIndex(a => a.MaterialGuid == mat.GetInstanceGuid().ExportedGuid);
                        if (idx == -1)
                            continue;

                        material = mv.Materials[idx];
                    }
                    if (material != null)
                    {
                        var texParams = new List<TextureShaderParameter>();
                        var addedParams = new List<string>();

                        foreach (string texPath in obj.Material.Textures)
                        {
                            string paramName = "";
                            string texName = Path.GetFileNameWithoutExtension(texPath);

                            // @todo: support for other game textures
                            if (texName.EndsWith("_ASM")) paramName = "ASM";
                            if (texName.EndsWith("_Color")) paramName = "Color";
                            if (texName.EndsWith("_Normal")) paramName = "Normal";
                            if (texName.EndsWith("_ETT")) paramName = "ETT";

                            // most likely a color/diffuse texture if there is only one
                            if (obj.Material.Textures.Count == 1)
                                paramName = "Color";

                            if (string.IsNullOrEmpty(paramName))
                                continue;

                            EbxAssetEntry texEntry = CreateTexture("_leveleditor/Textures/" + texName, textureSample, texPath);
                            AddTexParam(paramName, texEntry);

                            addedParams.Add(paramName);
                        }

                        if (!addedParams.Contains("ASM") && gameDefaults.ASMTexture != null) AddTexParam("ASM", gameDefaults.ASMTexture);
                        if (!addedParams.Contains("Color") && gameDefaults.ColorTexture != null) AddTexParam("Color", gameDefaults.ColorTexture);
                        if (!addedParams.Contains("Normal") && gameDefaults.NormalTexture != null) AddTexParam("Normal", gameDefaults.NormalTexture);
                        if (!addedParams.Contains("ETT") && gameDefaults.ETTTexture != null) AddTexParam("ETT", gameDefaults.ETTTexture);

                        void AddTexParam(string name, EbxAssetEntry entry)
                        {
                            texParams.Add(new TextureShaderParameter
                            {
                                ParameterName = name,
                                Value = new PointerRef(new EbxImportReference
                                {
                                    FileGuid = entry.Guid,
                                    ClassGuid = ((TextureAsset)App.AssetManager.GetEbx(entry).RootObject).__InstanceGuid.ExportedGuid
                                })
                            });
                        }

                        material.TextureParameters = texParams;
                    }
                    BundleManager.Instance.Manage(editor.AddedLayer.EnumerateBundles().ToList(), blueprint, material);

                    try
                    {
                        string fbx = Path.Combine(levelPath, "Meshes", obj.Name + ".fbx");

                        if (File.Exists(fbx))
                        {
                            var resEntry = App.AssetManager.GetResEntry((meshAsset.RootObject as MeshAsset).MeshSetResource);
                            var meshSet = App.AssetManager.GetResAs<MeshSet>(resEntry);

                            var fbxImporter = new FBXImporter(App.Logger);
                            fbxImporter.ImportFBX(fbx, meshSet, meshAsset, meshEntry);
                        }
                    }
                    catch (FBXImportInvalidLodCountException) // @todo: update frosty's FBX sdk to stop this
                    {
                    }
                }

                var transform = obj.Transform * Matrix.Translation(SharpDXUtils.FromVec3(importSettings.ObjectOffset));

                entities.AddRange(editor.AddEntities(App.AssetManager.GetEbxEntry(blueprintAssetPath), 1, transform,
                    addedLayer: sceneLayer, manageBundles: false, showTaskWindow: false, selectEntity: false));

                // @todo: implement collision generation with OBBCollision entities (not havok!).
                // would also include setting the mesh bounding box

                count++;
            }

            MeshVariationDb.LoadModifiedVariations();
            foreach (var entity in entities)
            {
                editor.UpdateMeshMaterials(entity);
            }

            return root;
        }

        private Matrix FromBlenderTransform(Vector3 location, Quaternion quaternion, Vector3 scale)
        {
            var conversion = new Matrix(
                1, 0, 0, 0,
                0, 0, 1, 0,
                0, -1, 0, 0,
                0, 0, 0, 1);

            var convertedTrans = new Vector3(location.X, location.Z, -location.Y);
            var convertedScale = new Vector3(scale.X, scale.Z, scale.Y);
            var convertedRotation = conversion * Matrix.RotationQuaternion(quaternion) * Matrix.Transpose(conversion);

            return Matrix.Scaling(convertedScale) * convertedRotation * Matrix.Translation(convertedTrans);
        }

        private void ApplyObjectBlueprintDefaults(EbxAsset blueprintAsset, ObjectBlueprint objBlueprint, EbxAssetEntry mesh)
        {
            var staticModelEntity = Utils.CreateEntityData(typeof(StaticModelEntityData), blueprintAsset) as StaticModelEntityData;
            var partComponentEntity = Utils.CreateEntityData(typeof(PartComponentData), blueprintAsset) as PartComponentData;
            var healthState = Utils.CreateEntityData(typeof(HealthStateData), blueprintAsset) as HealthStateData;

            healthState.CopyDamageToBanger = true;
            healthState.PhysicsEnabled = true;
            healthState.Health = 100;
            healthState.CanSupportOtherParts = true;
            healthState.RegenerateDelay = 1;
            healthState.RegenerateSpeed = 1;
            partComponentEntity.HealthStates = new List<PointerRef> { new PointerRef(internalRef: healthState) };
            staticModelEntity.Components = new List<PointerRef> { new PointerRef(internalRef: partComponentEntity) };
            staticModelEntity.ClientRuntimeComponentCount = 1;
            staticModelEntity.ServerRuntimeComponentCount = 1;
            staticModelEntity.ClientRuntimeTransformationCount = 1;
            staticModelEntity.ServerRuntimeTransformationCount = 1;
            staticModelEntity.Enabled = true;
            staticModelEntity.Mesh = CreateRef(mesh.Name, blueprintAsset);
            staticModelEntity.PhysicsPartInfos = new List<PhysicsPartInfo> { new PhysicsPartInfo() };
            staticModelEntity.NetworkInfo = new StaticModelNetworkInfo
            {
                PartNetworkIdRanges = new List<IndexRange>
                {
                    new IndexRange
                    {
                        First = 4294967295,
                        Last = 4294967295
                    }
                }
            };
            staticModelEntity.ExplosionSensitiveDistance = 2.5f;
            staticModelEntity.Visible = true;

            objBlueprint.Object = new PointerRef(internalRef: staticModelEntity);

            blueprintAsset.AddObject(staticModelEntity);
            blueprintAsset.AddObject(partComponentEntity);
            blueprintAsset.AddObject(healthState);
            App.AssetManager.ModifyEbx(objBlueprint.Name, blueprintAsset);
        }

        private void ApplyMeshDefaults(MeshMaterial meshMaterial, MeshAsset meshProperties, EbxAsset asset)
        {
            meshMaterial.CastShadow = true;
            meshMaterial.TessellationTriangleSize = 12;
            meshMaterial.TessellationMaxDistance = 20;
            meshMaterial.BackFaceCullEpsilon = 0.5f;
            meshMaterial.ShapeFactor = 0.75f;
            meshMaterial.DisplacementScale = 1;
            meshMaterial.DisplacementBias = 0.5f;

            // @todo: create lod group
            meshProperties.LodGroup = CreateRef("art/LodGroups/PvZ_World_PropsMedium", asset);
            meshProperties.LodScale = 1;
            meshProperties.CullScale = 1;
            meshProperties.CanReceiveDecals = true;
            meshProperties.CanReceiveMultiProjectDecals = true;
            meshProperties.StreamingEnable = true;
            meshProperties.OccluderIsConservative = true;
            meshProperties.EnlightenType = EnlightenType.EnlightenType_Static;
            meshProperties.EnlightenMeshLod = -1;
            meshProperties.LightmapUVsScaleCharts = true;
            meshProperties.AutoLightmapUVsMaxDistance = 0.3f;
            meshProperties.AutoLightmapUVsExpansionFactor = 0.2f;
            meshProperties.AutoLightmapUVsMaxNormalDeviation = 85;
            meshProperties.Materials = new List<PointerRef> { new PointerRef(internalRef: meshMaterial) };
        }

        private EbxAssetEntry CreateMesh(string name, Type type, MeshAsset sample)
        {
            name = name.ToLower();

            EbxAssetEntry entry = CreateAsset(name, type);
            EbxAsset asset = App.AssetManager.GetEbx(entry);
            MeshAsset meshProperties = asset.RootObject as MeshAsset;

            ResAssetEntry resAsset = DuplicateRes(App.AssetManager.GetResEntry(sample.MeshSetResource), name, ResourceType.MeshSet);
            MeshSet meshSet = App.AssetManager.GetResAs<MeshSet>(resAsset);
            meshSet.FullName = resAsset.Name;

            foreach (var lod in meshSet.Lods)
            {
                lod.Name = resAsset.Name;
                if (lod.ChunkId != Guid.Empty)
                {
                    var chunk = App.AssetManager.GetChunkEntry(lod.ChunkId);
                    var newChunk = DuplicateChunk(chunk);

                    lod.ChunkId = newChunk.Id;

                    resAsset.LinkAsset(newChunk);
                }
            }

            var meshMaterial = Utils.CreateEntityData(typeof(MeshMaterial), asset) as MeshMaterial;
            meshMaterial.Shader = new SurfaceShaderInstanceDataStruct
            {
                Shader = new PointerRef(new EbxImportReference
                {
                    FileGuid = gameDefaults.Shader.Guid,
                    ClassGuid = (App.AssetManager.GetEbx(gameDefaults.Shader).RootObject as ShaderGraph).__InstanceGuid.ExportedGuid
                }),
                // VectorParameters should also go here, but currently we're just using the default shader
            };
            meshProperties.MeshSetResource = resAsset.ResRid;
            meshProperties.NameHash = (uint)FrostySdk.Utils.HashString(name);

            ApplyMeshDefaults(meshMaterial, meshProperties, asset);

            // @todo: swbf2 has some shader block depot stuff, will have to do at some point here

            asset.AddObject(meshMaterial);
            asset.AddDependency(gameDefaults.Shader.Guid);
            entry.LinkAsset(resAsset);

            App.AssetManager.ModifyRes(resAsset.Name, meshSet);
            App.AssetManager.ModifyEbx(name, asset);

            return entry;
        }

        private EbxAssetEntry CreateTexture(string name, TextureAsset sample, string texturePath)
        {
            var existing = App.AssetManager.GetEbxEntry(name);
            if (existing != null)
                return existing;

            var entry = CreateAsset(name, TypeLibrary.GetType("TextureAsset"));
            var asset = App.AssetManager.GetEbx(entry);

            var resEntry = App.AssetManager.GetResEntry(sample.Resource);
            var texture = App.AssetManager.GetResAs<Texture>(resEntry);
            var chunkEntry = App.AssetManager.GetChunkEntry(texture.ChunkId);

            var newChunkEntry = DuplicateChunk(chunkEntry);

            var newResEntry = DuplicateRes(resEntry, name, ResourceType.Texture);
            ((TextureAsset)asset.RootObject).Resource = newResEntry.ResRid;
            Texture newTexture = App.AssetManager.GetResAs<Texture>(newResEntry);
            newTexture.ChunkId = newChunkEntry.Id;
            newTexture.AssetNameHash = (uint)FrostySdk.Utils.HashString(newResEntry.Name, true);

            ImportTexture(texturePath, ref newTexture, newResEntry.ResRid);

            newResEntry.LinkAsset(newChunkEntry);
            entry.LinkAsset(newResEntry);

            App.AssetManager.ModifyEbx(entry.Name, asset);
            App.AssetManager.ModifyRes(newResEntry.Name, newTexture);

            return entry;
        }

        private EbxAssetEntry CreateAsset(string name, Type type)
        {
            var existing = App.AssetManager.GetEbxEntry(name);
            if (existing != null)
                return existing;

            EbxAsset asset = new EbxAsset(TypeLibrary.CreateObject(type.Name));
            asset.SetFileGuid(Guid.NewGuid());

            dynamic obj = asset.RootObject;
            obj.Name = name;

            AssetClassGuid guid = new AssetClassGuid(FrostySdk.Utils.GenerateDeterministicGuid(asset.Objects, (Type)obj.GetType(), asset.FileGuid), -1);
            obj.SetInstanceGuid(guid);

           return App.AssetManager.AddEbx(name, asset);
        }

        private ResAssetEntry DuplicateRes(ResAssetEntry entry, string name, ResourceType resType)
        {
            var existing = App.AssetManager.GetResEntry(name);
            if (existing != null)
                return existing;

            ResAssetEntry newEntry;
            using (NativeReader reader = new NativeReader(App.AssetManager.GetRes(entry)))
            {
                newEntry = App.AssetManager.AddRes(name, resType, entry.ResMeta, reader.ReadToEnd());
            }

            return newEntry;
        }
        
        private ChunkAssetEntry DuplicateChunk(ChunkAssetEntry entry)
        {
            byte[] random = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            while (true)
            {
                rng.GetBytes(random);
                random[15] |= 1;

                if (App.AssetManager.GetChunkEntry(new Guid(random)) == null)
                    break;
            }

            Guid newGuid;
            using (NativeReader reader = new NativeReader(App.AssetManager.GetChunk(entry)))
            {
                newGuid = App.AssetManager.AddChunk(reader.ReadToEnd(), new Guid(random));
            }

            return App.AssetManager.GetChunkEntry(newGuid);
        }

        private PointerRef CreateRef(string name, EbxAsset asset)
        {
            EbxAssetEntry entry = App.AssetManager.GetEbxEntry(name);
            return CreateRef(entry, asset);
        }

        private PointerRef CreateRef(EbxAssetEntry entry, EbxAsset asset)
        {
            EbxAsset refAsset = App.AssetManager.GetEbx(entry);

            asset.AddDependency(entry.Guid);

            return new PointerRef(new EbxImportReference()
            {
                FileGuid = entry.Guid,
                ClassGuid = refAsset.RootInstanceGuid
            });
        }

        #region Import Texture
        // mostly copy+pasted from texture plugin

        private void ImportTexture(string texturePath, ref Texture texture, ulong resRid)
        {
            ImageFormat format = ImageFormat.PNG;
            if (texturePath.EndsWith(".png")) format = ImageFormat.PNG;
            if (texturePath.EndsWith(".tga")) format = ImageFormat.TGA;
            if (texturePath.EndsWith(".hdr")) format = ImageFormat.HDR;
            if (texturePath.EndsWith(".dds")) format = ImageFormat.DDS;

            BlobData blob = new BlobData();

            TextureImportOptions options = new TextureImportOptions
            {
                type = texture.Type,
                format = TextureUtils.ToShaderFormat(texture.PixelFormat, (texture.Flags & TextureFlags.SrgbGamma) != 0),
                generateMipmaps = texture.MipCount > 1,
                mipmapsFilter = 0,
                resizeTexture = false,
                resizeFilter = 0,
                resizeHeight = 0,
                resizeWidth = 0
            };

            byte[] buf = NativeReader.ReadInStream(new FileStream(texturePath, FileMode.Open, FileAccess.Read));
            FrostyTextureEditor.ConvertImageToDDS(buf, buf.Length, format, options, ref blob);
            MemoryStream memStream = new MemoryStream(blob.Data);

            using (NativeReader reader = new NativeReader(memStream))
            {
                TextureUtils.DDSHeader header = new TextureUtils.DDSHeader();
                if (header.Read(reader))
                {
                    GetPixelFormat(texture, header, out string pixelFormat, out TextureFlags baseFlags);

                    ResAssetEntry resEntry = App.AssetManager.GetResEntry(resRid);
                    ChunkAssetEntry chunkEntry = App.AssetManager.GetChunkEntry(texture.ChunkId);

                    // revert any modifications
                    //App.AssetManager.RevertAsset(resEntry, dataOnly: true);

                    byte[] buffer = new byte[reader.Length - reader.Position];
                    reader.Read(buffer, 0, (int)(reader.Length - reader.Position));

                    ushort depth = (header.HasExtendedHeader && header.ExtendedHeader.resourceDimension == D3D11.ResourceDimension.Texture2D)
                            ? (ushort)header.ExtendedHeader.arraySize
                            : (ushort)1;

                    // cubemaps are just 6 slice arrays
                    if ((header.dwCaps2 & TextureUtils.DDSCaps2.CubeMap) != 0)
                        depth = 6;
                    if ((header.dwCaps2 & TextureUtils.DDSCaps2.Volume) != 0)
                        depth = (ushort)header.dwDepth;

                    Texture newtexture = new Texture(texture.Type, pixelFormat, (ushort)header.dwWidth, (ushort)header.dwHeight, depth) { FirstMip = texture.FirstMip };
                    if (header.dwMipMapCount <= texture.FirstMip)
                        newtexture.FirstMip = 0;

                    newtexture.TextureGroup = texture.TextureGroup;
                    newtexture.CalculateMipData((byte)header.dwMipMapCount, TextureUtils.GetFormatBlockSize(pixelFormat), TextureUtils.IsCompressedFormat(pixelFormat), (uint)buffer.Length);
                    newtexture.Flags = baseFlags;

                    // just copy old flags (minus gamma) to new texture
                    TextureFlags oldFlags = texture.Flags & ~(TextureFlags.SrgbGamma);
                    newtexture.Flags |= oldFlags;

                    // rejig mips/slices
                    if (newtexture.Type == TextureType.TT_Cube || newtexture.Type == TextureType.TT_2dArray)
                    {
                        MemoryStream srcStream = new MemoryStream(buffer);
                        MemoryStream dstStream = new MemoryStream();

                        int sliceCount = 6;
                        if (newtexture.Type == TextureType.TT_2dArray)
                            sliceCount = newtexture.Depth;

                        // Need to rejig order of faces and mips
                        uint[] mipOffsets = new uint[newtexture.MipCount];
                        for (int i = 0; i < newtexture.MipCount - 1; i++)
                            mipOffsets[i + 1] = mipOffsets[i] + (uint)(newtexture.MipSizes[i] * sliceCount);

                        byte[] tmpBuf = new byte[newtexture.MipSizes[0]];

                        for (int slice = 0; slice < sliceCount; slice++)
                        {
                            for (int mip = 0; mip < newtexture.MipCount; mip++)
                            {
                                int mipSize = (int)newtexture.MipSizes[mip];

                                srcStream.Read(tmpBuf, 0, mipSize);
                                dstStream.Position = mipOffsets[mip] + (mipSize * slice);
                                dstStream.Write(tmpBuf, 0, mipSize);
                            }
                        }

                        buffer = dstStream.ToArray();
                    }

                    // modify chunk
                    if (ProfilesLibrary.MustAddChunks && chunkEntry.Bundles.Count == 0 && !chunkEntry.IsAdded)
                    {
                        // DAI requires adding new chunks if in chunks bundle
                        texture.ChunkId = App.AssetManager.AddChunk(buffer, null, (newtexture.Flags & TextureFlags.OnDemandLoaded) != 0 ? null : newtexture);
                        chunkEntry = App.AssetManager.GetChunkEntry(texture.ChunkId);
                    }
                    else
                    {
                        // other games just modify
                        App.AssetManager.ModifyChunk(texture.ChunkId, buffer, ((newtexture.Flags & TextureFlags.OnDemandLoaded) != 0 || newtexture.Type != TextureType.TT_2d) ? null : newtexture);
                    }

                    for (int i = 0; i < 4; i++)
                        newtexture.Unknown3[i] = texture.Unknown3[i];
                    newtexture.SetData(texture.ChunkId, App.AssetManager);
                    newtexture.AssetNameHash = (uint)Fnv1.HashString(resEntry.Name);

                    texture.Dispose();
                    texture = newtexture;
                }
            }

            FrostyTextureEditor.ReleaseBlob(blob);
        }

        private void GetPixelFormat(Texture texture, TextureUtils.DDSHeader header, out string pixelFormat, out TextureFlags flags)
        {
            pixelFormat = "Unknown";
            flags = 0;

            if (ProfilesLibrary.DataVersion == (int)ProfileVersion.DragonAgeInquisition || ProfilesLibrary.DataVersion == (int)ProfileVersion.Battlefield4 || ProfilesLibrary.DataVersion == (int)ProfileVersion.PlantsVsZombiesGardenWarfare)
            {
                // DXT1
                if (header.ddspf.dwFourCC == 0x31545844)
                {
                    pixelFormat = "BC1_UNORM";
                    if (texture.PixelFormat.Contains("Normal"))
                        pixelFormat = texture.PixelFormat;
                    else if (texture.PixelFormat.StartsWith("BC1A"))
                        pixelFormat = texture.PixelFormat;
                }

                // ATI2 or BC5U
                else if (header.ddspf.dwFourCC == 0x32495441 || header.ddspf.dwFourCC == 0x55354342)
                    pixelFormat = "NormalDXN";

                // DXT3
                else if (header.ddspf.dwFourCC == 0x33545844)
                    pixelFormat = "BC2_UNORM";

                // DXT5
                else if (header.ddspf.dwFourCC == 0x35545844)
                    pixelFormat = "BC3_UNORM";

                // ATI1
                else if (header.ddspf.dwFourCC == 0x31495441)
                    pixelFormat = "BC3A_UNORM";

                // All others
                else if (header.HasExtendedHeader)
                {
                    switch (header.ExtendedHeader.dxgiFormat)
                    {
                        case SharpDX.DXGI.Format.R32G32B32A32_Float: pixelFormat = "ARGB32F"; break;
                        case SharpDX.DXGI.Format.R9G9B9E5_Sharedexp: pixelFormat = "R9G9B9E5F"; break;
                        case SharpDX.DXGI.Format.R8_UNorm: pixelFormat = "L8"; break;
                        case SharpDX.DXGI.Format.R16_UNorm: pixelFormat = "L16"; break;
                        case SharpDX.DXGI.Format.R8G8B8A8_UNorm: pixelFormat = "ARGB8888"; break;
                        case SharpDX.DXGI.Format.BC1_UNorm:
                            pixelFormat = "BC1_UNORM";
                            if (texture.PixelFormat.Contains("Normal") || texture.PixelFormat.StartsWith("BC1A"))
                                pixelFormat = texture.PixelFormat;
                            break;
                        case SharpDX.DXGI.Format.BC2_UNorm: pixelFormat = "BC2_UNORM"; break;
                        case SharpDX.DXGI.Format.BC3_UNorm: pixelFormat = "BC3_UNORM"; break;
                        case SharpDX.DXGI.Format.BC5_UNorm: pixelFormat = "NormalDXN"; break;
                        case SharpDX.DXGI.Format.BC7_UNorm: pixelFormat = "BC7_UNORM"; break;
                        case SharpDX.DXGI.Format.BC1_UNorm_SRgb: pixelFormat = "BC1_UNORM"; flags = TextureFlags.SrgbGamma; break;
                        case SharpDX.DXGI.Format.BC2_UNorm_SRgb: pixelFormat = "BC2_UNORM"; flags = TextureFlags.SrgbGamma; break;
                        case SharpDX.DXGI.Format.BC3_UNorm_SRgb:
                            pixelFormat = (texture.PixelFormat == "BC3A_UNORM") ? texture.PixelFormat : "BC3_UNORM";
                            flags = TextureFlags.SrgbGamma;
                            break;
                        case SharpDX.DXGI.Format.BC7_UNorm_SRgb: pixelFormat = "BC7_UNORM"; flags = TextureFlags.SrgbGamma; break;
                    }
                }
            }
            else
            {
                // Newer format PixelFormats
                if (header.ddspf.dwFourCC == 0)
                {
                    if (header.ddspf.dwRBitMask == 0x000000FF && header.ddspf.dwGBitMask == 0x0000FF00 && header.ddspf.dwBBitMask == 0x00FF0000 && header.ddspf.dwABitMask == 0xFF000000)
                        pixelFormat = "R8G8B8A8_UNORM";
                }

                // DXT1
                else if (header.ddspf.dwFourCC == 0x31545844)
                {
                    pixelFormat = "BC1_UNORM";
                    if (texture.PixelFormat == "BC1A_UNORM")
                        pixelFormat = "BC1A_UNORM";
                }

                // DXT5
                else if (header.ddspf.dwFourCC == 0x35545844)
                    pixelFormat = "BC3_UNORM";

                // ATI1
                else if (header.ddspf.dwFourCC == 0x31495441)
                    pixelFormat = "BC4_UNORM";

                // ATI2 or BC5U
                else if (header.ddspf.dwFourCC == 0x32495441 || header.ddspf.dwFourCC == 0x55354342)
                    pixelFormat = "BC5_UNORM";

                // All others
                else if (header.HasExtendedHeader)
                {
                    if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.BC1_UNorm)
                    {
                        pixelFormat = "BC1_UNORM";
                        if (texture.PixelFormat == "BC1A_UNORM")
                            pixelFormat = "BC1A_UNORM";
                    }
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.BC3_UNorm)
                        pixelFormat = "BC3_UNORM";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.BC4_UNorm)
                        pixelFormat = "BC4_UNORM";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.BC5_UNorm)
                        pixelFormat = "BC5_UNORM";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.BC1_UNorm_SRgb && texture.PixelFormat == "BC1A_SRGB")
                        pixelFormat = "BC1A_SRGB";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.BC1_UNorm_SRgb)
                        pixelFormat = "BC1_SRGB";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.BC3_UNorm_SRgb)
                        pixelFormat = "BC3_SRGB";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.BC6H_Uf16)
                        pixelFormat = "BC6U_FLOAT";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.BC7_UNorm)
                        pixelFormat = "BC7_UNORM";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.BC7_UNorm_SRgb)
                        pixelFormat = "BC7_SRGB";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.R8_UNorm)
                        pixelFormat = "R8_UNORM";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.R16G16B16A16_Float)
                        pixelFormat = "R16G16B16A16_FLOAT";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.R32G32B32A32_Float)
                        pixelFormat = "R32G32B32A32_FLOAT";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.R9G9B9E5_Sharedexp)
                        pixelFormat = "R9G9B9E5_FLOAT";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.R8G8B8A8_UNorm)
                        pixelFormat = "R8G8B8A8_UNORM";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.R8G8B8A8_UNorm_SRgb)
                        pixelFormat = "R8G8B8A8_SRGB";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.R10G10B10A2_UNorm)
                        pixelFormat = "R10G10B10A2_UNORM";
                    else if (header.ExtendedHeader.dxgiFormat == SharpDX.DXGI.Format.R16_UNorm)
                    {
                        pixelFormat = "R16_UNORM";
                        if (texture.PixelFormat == "D16_UNORM")
                            pixelFormat = "D16_UNORM";
                    }
                }
            }
        }
        #endregion

        // since we currently cant modify the amount of sections in a mesh or create a brand new mesh,
        // find a mesh with a single section for all mesh types to duplicate later
        private void GetSamples()
        {
            if (skinnedSample != null && rigidSample != null && compositeSample != null && textureSample != null)
                return;

            foreach (var skinned in App.AssetManager.EnumerateEbx("SkinnedMeshAsset"))
            {
                if (!skinned.Bundles.Any(b => App.AssetManager.GetBundleEntry(b).Type == BundleType.SubLevel))
                    continue;

                if (!CheckReferencesTo(skinned, "ObjectBlueprint"))
                    continue;

                if (App.AssetManager.GetEbx(skinned).RootObject is SkinnedMeshAsset asset)
                {
                    if (asset.Materials.Count != 1)
                        continue;

                    int lods = App.AssetManager.GetResAs<MeshSet>(App.AssetManager.GetResEntry(asset.MeshSetResource)).Lods.Count;
                    if (lods != LodCount)
                        continue;

                    skinnedSample = asset;
                    break;
                }
            }

            foreach (var rigid in App.AssetManager.EnumerateEbx("RigidMeshAsset"))
            {
                if (!rigid.Bundles.Any(b => App.AssetManager.GetBundleEntry(b).Type == BundleType.SubLevel))
                    continue;

                if (!CheckReferencesTo(rigid, "ObjectBlueprint"))
                    continue;

                if (App.AssetManager.GetEbx(rigid).RootObject is RigidMeshAsset asset)
                {
                    if (asset.Materials.Count != 1)
                        continue;

                    int lods = App.AssetManager.GetResAs<MeshSet>(App.AssetManager.GetResEntry(asset.MeshSetResource)).Lods.Count;
                    if (lods != LodCount)
                        continue;

                    rigidSample = asset;
                    break;
                }
            }

            foreach (var composite in App.AssetManager.EnumerateEbx("CompositeMeshAsset"))
            {
                if (!composite.Bundles.Any(b => App.AssetManager.GetBundleEntry(b).Type == BundleType.SubLevel))
                    continue;

                if (!CheckReferencesTo(composite, "ObjectBlueprint"))
                    continue;

                if (App.AssetManager.GetEbx(composite).RootObject is CompositeMeshAsset asset)
                {
                    if (asset.Materials.Count != 1)
                        continue;

                    int lods = App.AssetManager.GetResAs<MeshSet>(App.AssetManager.GetResEntry(asset.MeshSetResource)).Lods.Count;
                    if (lods != LodCount)
                        continue;

                    compositeSample = asset;
                    break;
                }
            }

            foreach (var texture in App.AssetManager.EnumerateEbx("TextureAsset"))
            {
                if (!texture.Bundles.Any(b => App.AssetManager.GetBundleEntry(b).Type == BundleType.SubLevel))
                    continue;

                if (!CheckReferencesTo(texture, "MeshVariationDatabase"))
                    continue;

                if (App.AssetManager.GetEbx(texture).RootObject is TextureAsset asset)
                {
                    textureSample = asset;
                    break;
                }
            }
        }

        private bool CheckReferencesTo(EbxAssetEntry entry, string type)
        {
            bool matched = false;
            foreach (var subEntry in App.AssetManager.EnumerateEbx())
            {
                if (!subEntry.ContainsDependency(entry.Guid))
                    continue;

                if (subEntry.Type == type)
                {
                    matched = true;
                    break;
                }
            }

            return matched;
        }

        private GameDefaults GetDefaults()
        {
            switch ((ProfileVersion)ProfilesLibrary.DataVersion)
            {
                case ProfileVersion.PlantsVsZombiesGardenWarfare2:
                    return new GameDefaults
                    {
                        Shader = App.AssetManager.GetEbxEntry("art/Shaders/Props/PBR_Object_Main"),
                        ASMTexture = App.AssetManager.GetEbxEntry("art/Textures/Generic/Default_ASM"),
                        ColorTexture = App.AssetManager.GetEbxEntry("art/Textures/Generic/Default_Color"),
                        NormalTexture = App.AssetManager.GetEbxEntry("art/Textures/Generic/Default_Normal"),
                        ETTTexture = App.AssetManager.GetEbxEntry("art/Textures/Generic/Default_ETT"),
                    };

                // @todo: defaults for PvZ GW1, also SWBF2 and Mass Effect, but i don't own those

                default:
                    App.Logger.LogError("Couldn't get defaults for " + ProfilesLibrary.ProfileName);
                    return new GameDefaults();
            }
        }
    }
}
