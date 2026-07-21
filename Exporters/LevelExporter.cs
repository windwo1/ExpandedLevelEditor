using Frosty.Core;
using Frosty.Core.Controls;
using Frosty.Core.Viewport;
using Frosty.Core.Windows;
using FrostySdk;
using FrostySdk.Attributes;
using FrostySdk.Ebx;
using FrostySdk.IO;
using FrostySdk.Managers.Entries;
using FrostySdk.Resources;
using LevelEditorPlugin.Data;
using LevelEditorPlugin.Entities;
using LevelEditorPlugin.Layers;
using LevelEditorPlugin.Render;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using TexturePlugin;

namespace LevelEditorPlugin.Exporters
{
    public class LevelExportSettings
    {
        [DisplayName("Mesh LOD")]
        public int LODIndex { get; set; } = 0;

        [DisplayName("Export Prefabs")]
        public bool ExportPrefabs { get; set; } = true;

        [DisplayName("Use Alpha In Materials")]
        public bool UseAlpha { get; set; } = true;

#if !GW1
        [DisplayName("Use Emission In Materials")]
        public bool UseEmission { get; set; } = false;
#endif
        [DisplayName("Terrain Decimation (none = 1)")]
        public float TerrainDecimation { get; set; } = 0.05f;
    }

    public class LevelExporter
    {
        private SceneLayer rootLayer;
        private LevelExportSettings exportSettings;

        public LevelExporter(SceneLayer root)
        {
            rootLayer = root;

            exportSettings = new LevelExportSettings();

            if (FrostyImportExportBox.Show("Level Export Settings", FrostyImportExportType.Export, exportSettings) == MessageBoxResult.OK)
            {
                ExportLevel();
            }
        }

        private void ExportLevel()
        {
            List<SceneLayer> layers = new List<SceneLayer>();
            rootLayer.CollectLayers(layers);

            List<Entities.Entity> entityList = new List<Entities.Entity>();
            rootLayer.CollectEntities(entityList);

            //App.Logger.Log("Exporting {0} static model instances", entities.Count());
            string rootLayerName = rootLayer.LayerName;
            FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().FullName);

            string basePath = Path.Combine(Environment.CurrentDirectory, "Levels", rootLayerName);

            string meshPath = Path.Combine(basePath, "Meshes");
            string terrainPath = Path.Combine(basePath, "TerrainChunks");
            string texturePath = Path.Combine(basePath, "Textures");
            string lightingPath = Path.Combine(basePath, "Lights");

            Directory.CreateDirectory(basePath);
            Directory.CreateDirectory(meshPath);
            Directory.CreateDirectory(terrainPath);
            Directory.CreateDirectory(texturePath);
            Directory.CreateDirectory(lightingPath);

            Dictionary<string, bool> hasExportedMesh = new Dictionary<string, bool>();

            Stopwatch timer = new Stopwatch();
            timer.Start();

            FrostyTaskWindow.Show("Exporting " + rootLayerName, "", (task) =>
            {
                uint totalCount = (uint)layers.Count();

                uint smiCount = 0; //Static Model Instances
                uint objCount = 0; //ObjectRefs
                uint spatialCount = 0; //SpatialObjRefs

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = true,
                };
                XmlWriter xmlWriter = XmlWriter.Create(Path.Combine(meshPath, rootLayerName) + ".xml", settings);
                XmlWriter xmlWriterMaterials = XmlWriter.Create(Path.Combine(basePath, "Materials.xml"), settings);

                xmlWriter.WriteStartElement("FrostbiteLevel");
                xmlWriter.WriteElementString("Name", rootLayerName);
                xmlWriter.WriteElementString("Game", ProfilesLibrary.ProfileName);

                xmlWriter.WriteStartElement("Settings");

                xmlWriter.WriteElementString("LODIndex", exportSettings.LODIndex.ToString());
                xmlWriter.WriteElementString("ExportPrefabs", exportSettings.ExportPrefabs.ToString());
                xmlWriter.WriteElementString("UseAlpha", exportSettings.UseAlpha.ToString());
#if !GW1
                xmlWriter.WriteElementString("UseEmission", exportSettings.UseEmission.ToString());
#endif
                xmlWriter.WriteElementString("TerrainDecimation", exportSettings.TerrainDecimation.ToString());

                xmlWriter.WriteEndElement();

                xmlWriterMaterials.WriteStartElement("Materials");

                FBXExporter exporter = new FBXExporter(task);

                foreach (SceneLayer item in layers)
                {
                    if (!(item.LayerName == "static_instances"))
                    {
                        xmlWriter.WriteStartElement("WorldLayer");
                        xmlWriter.WriteElementString("Name", item.LayerName);

                        List<Entities.Entity> entities = new List<Entities.Entity>();
                        item.CollectEntities(entities);

                        ExportObjects(entities.Cast<object>().ToList(), xmlWriter, xmlWriterMaterials, task, exporter, hasExportedMesh,
                                ref smiCount, ref objCount, ref spatialCount);

                        xmlWriter.WriteEndElement();
                    }
                }

                // export any objects in the entity list for spatial prefabs or object blueprint assets
                ExportObjects(entityList.Cast<object>().ToList(), xmlWriter, xmlWriterMaterials, task, exporter, hasExportedMesh,
                                ref smiCount, ref objCount, ref spatialCount);

                xmlWriter.WriteEndElement();
                xmlWriterMaterials.WriteEndElement();

                xmlWriter.Dispose();
                xmlWriterMaterials.Dispose();

                foreach (Entities.Entity entity in entityList)
                {
#if GW1
                    if (entity is Entities.PointLightEntity light)
#else
                    if (entity is Entities.PbrSphereLightEntity light)
#endif
                    {
                        EbxAssetEntry entry = App.AssetManager.GetEbxEntry(light.Owner.FileGuid);

                        task.Update($"Exporting Lights ({entry.DisplayName})");

                        AssetDefinition assetDefinition = App.PluginManager.GetAssetDefinition(entry.Type) ?? new AssetDefinition();

                        string path = Path.Combine(lightingPath, entry.DisplayName);

                        if (!File.Exists(path + ".xml"))
                        {
                            assetDefinition.Export(entry, path + ".xml", "xml");
                        }
                    }

                    if (entity is TerrainEntity)
                    {
                        TerrainEntity terrainEntity = entity as TerrainEntity;

                        int index = 0;

                        foreach (TerrainChunkRenderable terrainChunk in terrainEntity.Terrain.TerrainData.TerrainChunks)
                        {
                            task.Update($"Exporting Terrain ({terrainChunk.Level}_{index})");

                            terrainChunk.ExportToOBJ(Path.Combine(terrainPath, $"chunk_{terrainChunk.Level}_{index}.obj"));
                            index++;
                        }
                    }
                }

                timer.Stop();

                App.Logger.Log("Exported {0} static models, {1} objects, {2} spatialprefabs in {3}", smiCount, objCount, spatialCount, timer.Elapsed);
            });
        }

        private void ExportObjects(List<object> objects, XmlWriter xmlWriter, XmlWriter xmlWriterMaterials, FrostyTaskWindow task, FBXExporter exporter, Dictionary<string, bool> hasExportedMesh, ref uint smiCount, ref uint objCount, ref uint spatialCount, LinearTransform offset = null)
        {
            string basePath = Path.Combine(Environment.CurrentDirectory, "Levels", rootLayer.LayerName);

            string meshPath = Path.Combine(basePath, "Meshes");
            string texturePath = Path.Combine(basePath, "Textures");
            string lightingPath = Path.Combine(basePath, "Lights");

            xmlWriter.WriteStartElement("StaticModelInstances");

            int count = 0;
            foreach (object entity in objects.Where(e => e is StaticModelGroupElementEntity || e is StaticModelGroupElementEntityData))
            {
                xmlWriter.WriteStartElement("StaticModelGroupElementEntity");

                StaticModelGroupElementEntityData smiData = (entity as StaticModelGroupElementEntity)?.Data ?? entity as StaticModelGroupElementEntityData;

                //Get required assets (Object blueprint, mesh asset)
                EbxAssetEntry objBlueprint = App.AssetManager.GetEbxEntry(smiData.Blueprint.External.FileGuid);

                if (objBlueprint == null)
                    continue;

                EbxAsset objAsset = App.AssetManager.GetEbx(objBlueprint);

                dynamic objRootAsset = objAsset.RootObject;

                EbxAssetEntry objMeshAsset = App.AssetManager.GetEbxEntry((objRootAsset.Object.Internal).Mesh.External.FileGuid);

                string path = Path.Combine(meshPath, objBlueprint.DisplayName + "_mesh.fbx");

                EbxAsset meshAssetEbx = App.AssetManager.GetEbx(objMeshAsset);
                dynamic meshAsset = meshAssetEbx.RootObject;

                if (!hasExportedMesh.TryGetValue(path, out var _))
                {
                    if (objMeshAsset == null)
                        continue;

                    //Update task

                    task.Update("StaticModel " + objMeshAsset.DisplayName);

                    //App.Logger.Log("{0}: {1}", objMeshAsset.DisplayName, smiTransform.ToString());

                    ResAssetEntry res = App.AssetManager.GetResEntry(meshAsset.MeshSetResource);
                    var meshSet = App.AssetManager.GetResAs<MeshSetPlugin.Resources.MeshSet>(res);

                    exporter.ExportFBX(meshAsset, path, "2017", "Meters", exportSettings.LODIndex, "binary", meshSet);

                    MeshMaterialCollection materials = new MeshMaterialCollection(
                        App.AssetManager.GetEbx(objMeshAsset),
                        new PointerRef()
                    );

                    ExportParameters(materials, objMeshAsset, objBlueprint, texturePath, meshSet, xmlWriterMaterials);
                    WriteSectionsToXML(materials, xmlWriter, objMeshAsset, objBlueprint, meshSet);

                    hasExportedMesh[path] = true;
                }

                LinearTransform transform = smiData.Transform;
                if (offset != null)
                {
                    transform = Entities.Entity.MakeLinearTransform(
                        SharpDXUtils.FromLinearTransform(transform) *
                        SharpDXUtils.FromLinearTransform(offset)
                        );
                }

                xmlWriter.WriteElementString("Blueprint", objBlueprint.Name);
                WriteTransformToXML(xmlWriter, transform);
                xmlWriter.WriteEndElement();

                smiCount++;
                count++;
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteElementString("StaticInstanceCount", count.ToString());
            xmlWriter.WriteStartElement("Objects");

            int instanceCount = 0;

#if GW1
            foreach (object entity in objects.Where(e => e is ReferenceObject || e is ReferenceObjectData))
#else
            foreach (object entity in objects.Where(e => e is ObjectReferenceObject || e is ObjectReferenceObjectData))
#endif
            {
#if GW1
                ReferenceObjectData data = (entity as ReferenceObject)?.Data ?? entity as ReferenceObjectData;
#else
                ObjectReferenceObjectData data = (entity as ObjectReferenceObject)?.Data ?? entity as ObjectReferenceObjectData;
#endif
                if (data.GetType().Name == "ObjectReferenceObjectData" || data.GetType().Name == "ReferenceObjectData")
                {
                    EbxAssetEntry objBlueprint = App.AssetManager.GetEbxEntry(data.Blueprint.External.FileGuid);

                    LinearTransform blueprintTransform = data.BlueprintTransform;

                    if (offset != null)
                    {
                        blueprintTransform = Entities.Entity.MakeLinearTransform(
                            SharpDXUtils.FromLinearTransform(blueprintTransform) *
                            SharpDXUtils.FromLinearTransform(offset)
                            );
                    }

                    if (ExportObjectBlueprint(objBlueprint, blueprintTransform, meshPath, texturePath, xmlWriter, xmlWriterMaterials, task, exporter, hasExportedMesh))
                    {
                        objCount++;
                        instanceCount++;
                    }
                }
            }

            foreach (object entity in objects.Where(e => e is ReferenceObject || e is ReferenceObjectData))
            {
                ReferenceObjectData data = (entity as ReferenceObject)?.Data ?? entity as ReferenceObjectData;

                EbxAssetEntry objBlueprint = App.AssetManager.GetEbxEntry(data.Blueprint.External.FileGuid);

                if (objBlueprint != null)
                {
                    LinearTransform blueprintTransform = data.BlueprintTransform;

                    if (offset != null)
                    {
                        blueprintTransform = Entities.Entity.MakeLinearTransform(
                            SharpDXUtils.FromLinearTransform(blueprintTransform) *
                            SharpDXUtils.FromLinearTransform(offset)
                            );
                    }

                    if (objBlueprint.Type == "ObjectBlueprint")
                    {
                        if (ExportObjectBlueprint(objBlueprint, blueprintTransform, meshPath, texturePath, xmlWriter, xmlWriterMaterials, task, exporter, hasExportedMesh))
                        {
                            objCount++;
                            instanceCount++;
                        }

                        continue;
                    }

                    if (objBlueprint.Type != "SpatialPrefabBlueprint" || !exportSettings.ExportPrefabs)
                        continue;

                    xmlWriter.WriteStartElement("SpatialPrefabInstance");

                    EbxAsset asset = App.AssetManager.GetEbx(objBlueprint);
                    dynamic rootObject = asset.RootObject;

                    task.Update("SpatialPrefab " + objBlueprint.Name);

                    xmlWriter.WriteElementString("Blueprint", objBlueprint.Name);
                    WriteTransformToXML(xmlWriter, blueprintTransform);
                    xmlWriter.WriteEndElement();

                    ExportObjects(asset.Objects.ToList(), xmlWriter, xmlWriterMaterials, task, exporter, hasExportedMesh,
                        ref smiCount, ref objCount, ref spatialCount, blueprintTransform);

                    // also export any lights in the prefab
                    foreach (var obj in asset.Objects)
                    {
#if GW1
                        if (obj is PointLightEntityData light)
#else
                        if (obj is PbrSphereLightEntityData light)
#endif
                        {
                            AssetDefinition assetDefinition = App.PluginManager.GetAssetDefinition(objBlueprint.Type) ?? new AssetDefinition();

                            string path = Path.Combine(lightingPath, objBlueprint.DisplayName);

                            if (!File.Exists(path + ".xml"))
                            {
                                assetDefinition.Export(objBlueprint, path + ".xml", "xml");
                            }

                            break;
                        }
                    }

                    objCount++;
                    instanceCount++;
                    spatialCount++;
                }
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteElementString("ObjectCount", instanceCount.ToString());
        }

        private bool ExportObjectBlueprint(EbxAssetEntry objBlueprint, LinearTransform transform, string meshPath, string texturePath, XmlWriter xmlWriter, XmlWriter xmlWriterMaterials, FrostyTaskWindow task, FBXExporter exporter, Dictionary<string, bool> hasExportedMesh)
        {
            if (objBlueprint == null)
                return false;

            EbxAsset objAsset = App.AssetManager.GetEbx(objBlueprint, false);
            dynamic objRootAsset = objAsset.RootObject;

            EbxAssetEntry objMeshAsset;

            try
            {
                objMeshAsset = App.AssetManager.GetEbxEntry(objRootAsset.Object.Internal.Mesh.External.FileGuid);
            }
            catch { return false; }

            if (objMeshAsset == null)
                return false;

            task.Update("Object " + objMeshAsset.DisplayName);

            xmlWriter.WriteStartElement("ObjectInstance");
            xmlWriter.WriteElementString("Blueprint", objBlueprint.Name);
            WriteTransformToXML(xmlWriter, transform);

            string path = Path.Combine(meshPath, objBlueprint.DisplayName + "_mesh.fbx");

            EbxAsset meshAssetEbx = App.AssetManager.GetEbx(objMeshAsset);
            dynamic meshAsset = meshAssetEbx.RootObject;

            if (!hasExportedMesh.TryGetValue(path, out var _))
            {
                ResAssetEntry res = App.AssetManager.GetResEntry(meshAsset.MeshSetResource);
                var meshSet = App.AssetManager.GetResAs<MeshSetPlugin.Resources.MeshSet>(res);

                exporter.ExportFBX(meshAsset, path, "2017", "Meters", exportSettings.LODIndex, "binary", meshSet);

                MeshMaterialCollection materials = new MeshMaterialCollection(
                    App.AssetManager.GetEbx(objMeshAsset),
                    new PointerRef()
                );

                ExportParameters(materials, objMeshAsset, objBlueprint, texturePath, meshSet, xmlWriterMaterials);
                WriteSectionsToXML(materials, xmlWriter, objMeshAsset, objBlueprint, meshSet);

                hasExportedMesh[path] = true;
            }

            xmlWriter.WriteEndElement();

            return true;
        }

        private void WriteTransformToXML(XmlWriter xmlWriter, LinearTransform smiTransform)
        {
            xmlWriter.WriteStartElement("Transform");
            xmlWriter.WriteStartElement("LinearTransform");
            xmlWriter.WriteStartElement("right");
            WriteVec3ToXML(xmlWriter, smiTransform.right.x.ToString(), smiTransform.right.y.ToString(), smiTransform.right.z.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("up");
            WriteVec3ToXML(xmlWriter, smiTransform.up.x.ToString(), smiTransform.up.y.ToString(), smiTransform.up.z.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("forward");
            WriteVec3ToXML(xmlWriter, smiTransform.forward.x.ToString(), smiTransform.forward.y.ToString(), smiTransform.forward.z.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("trans");
            WriteVec3ToXML(xmlWriter, smiTransform.trans.x.ToString(), smiTransform.trans.y.ToString(), smiTransform.trans.z.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }

        private void WriteVec3ToXML(XmlWriter xmlWriter, string x, string y, string z)
        {
            xmlWriter.WriteStartElement("Vec3");
            xmlWriter.WriteElementString("x", x);
            xmlWriter.WriteElementString("y", y);
            xmlWriter.WriteElementString("z", z);
            xmlWriter.WriteEndElement();
        }

        private void WriteVec4ToXML(XmlWriter xmlWriter, string x, string y, string z, string w)
        {
            xmlWriter.WriteStartElement("Vec4");
            xmlWriter.WriteElementString("x", x);
            xmlWriter.WriteElementString("y", y);
            xmlWriter.WriteElementString("z", z);
            xmlWriter.WriteElementString("w", w);
            xmlWriter.WriteEndElement();
        }

        private void WriteSectionsToXML(MeshMaterialCollection materials, XmlWriter xmlWriter, EbxAssetEntry meshAssetEbx, EbxAssetEntry objBlueprint, MeshSetPlugin.Resources.MeshSet meshSet)
        {
            xmlWriter.WriteStartElement("Sections");

            var sections = meshSet.Lods[0].Sections.ToList();

            for (int i = 0; i < Math.Min(materials.Count, sections.Count); i++)
            {
                xmlWriter.WriteStartElement("Section");
                var section = sections[i];

                string materialName = section.Name.Contains("lambert") ? $"{objBlueprint.DisplayName}:{i}" : section.Name;
                xmlWriter.WriteElementString("Name", materialName);

                xmlWriter.WriteEndElement(); // Section
            }

            xmlWriter.WriteEndElement(); // Sections
        }

        private TextureExporter textureExporter = new TextureExporter();

        private void ExportParameters(MeshMaterialCollection materials, EbxAssetEntry meshAssetEbx, EbxAssetEntry objBlueprint, string path, MeshSetPlugin.Resources.MeshSet meshSet, XmlWriter xmlWriter)
        {
            try
            {
                xmlWriter.WriteStartElement("Material");
                xmlWriter.WriteElementString("Name", meshAssetEbx.Name);

                var sections = meshSet.Lods[0].Sections.ToList();

                for (int i = 0; i < Math.Min(materials.Count, sections.Count); i++)
                {
                    var material = materials[i];
                    var section = sections[i];

                    // 'lambert' is used in a lot of material names, so when importing to blender it can mix up the materials
                    // so the mesh name is used instead
                    string materialName = section.Name.Contains("lambert") ? $"{objBlueprint.DisplayName}:{i}" : section.Name;

                    xmlWriter.WriteStartElement("Material");
                    xmlWriter.WriteElementString("Name", materialName);

                    xmlWriter.WriteStartElement("VectorParameters");

                    foreach (var vectorParam in material.VectorParameters)
                    {
                        xmlWriter.WriteStartElement("Parameter");

                        xmlWriter.WriteElementString("ParameterName", vectorParam.ParameterName.ToString());
                        xmlWriter.WriteElementString("ParameterType", vectorParam.ParameterType.ToString());

                        xmlWriter.WriteStartElement("Value");
                        WriteVec4ToXML(xmlWriter, vectorParam.Value.x.ToString(), vectorParam.Value.y.ToString(), vectorParam.Value.z.ToString(), vectorParam.Value.w.ToString());
                        xmlWriter.WriteEndElement(); // Value

                        xmlWriter.WriteEndElement(); // Parameter
                    }

                    xmlWriter.WriteEndElement(); // VectorParameters

                    xmlWriter.WriteStartElement("TextureParameters");

                    foreach (var textureParam in material.TextureParameters)
                    {
                        xmlWriter.WriteStartElement("Parameter");
                        var textureRef = textureParam.Value;

                        Guid guid = textureRef.External.FileGuid;

                        EbxAssetEntry textureEntry = App.AssetManager.GetEbxEntry(guid);

                        EbxAsset textureAsset = App.AssetManager.GetEbx(textureEntry);
                        dynamic rootObjectTexture = textureAsset.RootObject;

                        ulong textureRes = rootObjectTexture.Resource;
                        ResAssetEntry resEntry = App.AssetManager.GetResEntry(textureRes);

                        Texture texture = App.AssetManager.GetResAs<Texture>(resEntry);

                        string name = textureEntry.DisplayName + ".png";
                        string finalPath = Path.Combine(path, name);

                        if (!File.Exists(finalPath))
                        {
                            textureExporter.Export(texture, finalPath, "*.png");
                        }

                        xmlWriter.WriteElementString("ParameterName", textureParam.ParameterName);
                        xmlWriter.WriteElementString("Value", textureEntry.DisplayName);

                        xmlWriter.WriteEndElement(); // Parameter
                    }

                    xmlWriter.WriteEndElement(); // TextureParameters

                    xmlWriter.WriteEndElement(); // Material
                }

                xmlWriter.WriteEndElement(); // Materials
            }
            catch (Exception ex)
            {
                App.Logger.LogError($"Failed to get a texture or vector paramater. Failed Asset: {meshAssetEbx.Name}. Exception: {ex.Message}");
            }
        }
    }
}
