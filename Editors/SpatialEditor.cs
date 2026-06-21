using Frosty.Controls;
using Frosty.Core;
using Frosty.Core.Controls;
using Frosty.Core.Viewport;
using Frosty.Core.Windows;
using FrostySdk;
using FrostySdk.Ebx;
using FrostySdk.Interfaces;
using FrostySdk.IO;
using FrostySdk.Managers.Entries;
using FrostySdk.Resources;
using LevelEditorPlugin.Controls;
using LevelEditorPlugin.Data;
using LevelEditorPlugin.Entities;
using LevelEditorPlugin.Layers;
using LevelEditorPlugin.Render;
using LevelEditorPlugin.Screens;
using MeshSetPlugin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using TexturePlugin;

namespace LevelEditorPlugin.Editors
{
    public interface IEditorProvider
    {
        LevelEditorScreen Screen { get; }
        SceneLayer RootLayer { get; }

        void SelectLayer(Layers.SceneLayer newSelection);
        void SelectEntity(Entities.Entity newSelection);
        void CenterOnSelection();

        event EventHandler<SelectedEntityChangedEventArgs> SelectedEntityChanged;
        event EventHandler<SelectedLayerChangedEventArgs> SelectedLayerChanged;
    }

    public interface IWorldProvider
    {
        EntityWorld World { get; }
    }

    [TemplatePart(Name = "PART_ThumbnailBorder", Type = typeof(System.Windows.Shapes.Rectangle))]
    public class SpatialEditor : ToolbarAssetEditor, IEditorProvider
    {
        protected class LoadingStateInfo
        {
            public FrostyTaskWindow Task;
            public ILogger Logger;
        }
        protected static LoadingStateInfo currentLoadingState;

        public SceneLayer RootLayer => rootLayer;
        public SceneLayer SelectedLayer => selectedLayer;
        public LevelEditorScreen Screen => screen;
        public DockManager DockManager => dockManager;

        protected LevelEditorScreen screen;

        protected ReferenceObject editingWorld;
        protected SceneLayer rootLayer;
        protected EntityWorld world;

        protected Entities.Entity selectedEntity;
        protected SceneLayer selectedLayer;

        protected DockManager dockManager;

        protected System.Windows.Shapes.Rectangle thumbnailBorder;

        public event EventHandler<SelectedEntityChangedEventArgs> SelectedEntityChanged;
        public event EventHandler<SelectedLayerChangedEventArgs> SelectedLayerChanged;

        static SpatialEditor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpatialEditor), new FrameworkPropertyMetadata(typeof(SpatialEditor)));
        }

        public SpatialEditor(ILogger inLogger)
            : base(inLogger)
        {
            dockManager = new DockManager(this);
        }

        public void SelectEntity(Entities.Entity newSelection)
        {
            if (newSelection != selectedEntity)
            {
                // Select the root world if nothing else is selected
                Entities.Entity tmpSelection = newSelection;
                if (tmpSelection == null)
                    tmpSelection = editingWorld;

                SelectedEntityChanged?.Invoke(this, new SelectedEntityChangedEventArgs(tmpSelection, selectedEntity));
                selectedEntity = newSelection;
            }

            screen.SelectEntity(selectedEntity);
        }

        public void CenterOnSelection()
        {
            screen.CenterOnSelection();
        }

        public void SelectLayer(SceneLayer newSelection)
        {
            if (newSelection != selectedLayer)
            {
                SceneLayer oldSelection = selectedLayer;
                selectedLayer = newSelection;

                SelectedLayerChanged?.Invoke(this, new SelectedLayerChangedEventArgs(newSelection, oldSelection));
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            thumbnailBorder = GetTemplateChild("PART_ThumbnailBorder") as System.Windows.Shapes.Rectangle;
            PerformTemplateMagic();
        }

        public override void Closed()
        {
            DockManager.Shutdown();
            editingWorld.Destroy();

            base.Closed();
        }

        protected override void Reload()
        {
            DockManager.ShowFloatingWindows();
            screen.SetCamera();
        }

        protected override void Unload()
        {
            DockManager.HideFloatingWindows();
        }

        // @temp
        protected SceneLayer MakeFakeLayer()
        {
            string layerName = Path.GetFileName(editingWorld.Blueprint.Name);
            SceneLayer layer = new SceneLayer(editingWorld, layerName, new SharpDX.Color(0.0f, 0.5f, 0.0f, 1.0f));

            List<Entities.Entity> entities = (List<Entities.Entity>)editingWorld.GetType().GetField("entities", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(editingWorld);
            foreach (Entities.Entity entity in entities)
            {
                if (entity is ILayerEntity)
                {
                    ILayerEntity entityLayer = entity as ILayerEntity;
                    SceneLayer childLayer = entityLayer.GetLayer();
                    if (childLayer != null)
                        layer.ChildLayers.Add(childLayer);
                }
                else
                {
                    layer.AddEntity(entity);
                    entity.SetOwner(entity);
                }
            }

            return layer;
        }

        protected void ShowThumbnailSafeZone(bool show, FrostyViewport viewport)
        {
            thumbnailBorder.Visibility = (show) ? Visibility.Visible : Visibility.Collapsed;
            if (show)
            {
                double shortestSide = (viewport.ViewportHeight > viewport.ViewportWidth) ? viewport.ViewportWidth : viewport.ViewportHeight;
                thumbnailBorder.Width = shortestSide;
                thumbnailBorder.Height = shortestSide;
            }
        }

        protected void CaptureThumbnail(FrostyViewport viewport)
        {
            string thumbnailPath = $"{App.ProfileSettingsPath}/Thumbnails/{Asset.FileGuid}.png";
            FileInfo fi = new FileInfo(thumbnailPath);

            if (!Directory.Exists(fi.DirectoryName))
                Directory.CreateDirectory(fi.DirectoryName);

            double origWidth = viewport.ViewportWidth;
            double origHeight = viewport.ViewportHeight;

            viewport.SetPaused(true);
            Thread.Sleep(100);

            viewport.Width = 256;
            viewport.Height = 256;

            viewport.Measure(new Size(256, 256));
            viewport.Arrange(new Rect(0, 0, 256, 256));

            viewport.GetType().GetMethod("DisposeSizeDependentBuffers", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(viewport, null);
            viewport.GetType().GetMethod("CreateSizeDependentBuffers", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(viewport, null);

            screen.CaptureThumbnail(fi.FullName);

            viewport.Width = double.NaN;
            viewport.Height = double.NaN;

            viewport.Measure(new Size(origWidth, origHeight));
            viewport.Arrange(new Rect(0, 0, origWidth, origHeight));

            viewport.GetType().GetMethod("DisposeSizeDependentBuffers", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(viewport, null);
            viewport.GetType().GetMethod("CreateSizeDependentBuffers", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(viewport, null);
            viewport.SetPaused(false);

            App.NotificationManager.Show("Thumbnail created");
        }

        public static void UpdateTask(string status = null, double? progress = null)
        {
            if (currentLoadingState != null)
            {
                currentLoadingState.Task.Update(status, progress);
            }
        }

        public void ExportLevel()
        {
            List<SceneLayer> layers = new List<SceneLayer>();
            RootLayer.CollectLayers(layers);

            List<Entities.Entity> entityList = new List<Entities.Entity>();
            RootLayer.CollectEntities(entityList);

            //App.Logger.Log("Exporting {0} static model instances", entities.Count());
            string rootLayerName = RootLayer.LayerName;
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
                #region Meshes
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
                #endregion

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

        // this is a seperate method because it was gonna recursively export spatial prefabs but it got messy
        // if anyone else wants to try that i have left it like this so it's easier
        private void ExportObjects(List<object> objects, XmlWriter xmlWriter, XmlWriter xmlWriterMaterials, FrostyTaskWindow task, FBXExporter exporter, Dictionary<string, bool> hasExportedMesh, ref uint smiCount, ref uint objCount, ref uint spatialCount, List<string> spatialPaths = null)
        {
            string basePath = Path.Combine(Environment.CurrentDirectory, "Levels", RootLayer.LayerName);

            string meshPath = Path.Combine(basePath, "Meshes");
            string texturePath = Path.Combine(basePath, "Textures");

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

                    exporter.ExportFBX(meshAsset, path, "2017", "Meters", false, true, string.Empty, "binary", App.AssetManager.GetResAs<MeshSetPlugin.Resources.MeshSet>(res));

                    MeshMaterialCollection materials = new MeshMaterialCollection(
                        App.AssetManager.GetEbx(objMeshAsset),
                        new PointerRef()
                    );

                    ulong resRid = meshAsset.MeshSetResource;
                    ResAssetEntry rEntry = App.AssetManager.GetResEntry(resRid);

                    var meshSet = App.AssetManager.GetResAs<MeshSetPlugin.Resources.MeshSet>(rEntry);
                    ExportParameters(materials, objMeshAsset, objBlueprint, texturePath, meshSet, xmlWriterMaterials);
                    WriteSectionsToXML(materials, xmlWriter, objMeshAsset, objBlueprint, meshSet);

                    hasExportedMesh[path] = true;
                }

                LinearTransform transform = smiData.Transform;

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
                xmlWriter.WriteStartElement("SpatialPrefabInstance");

#if GW1
                ReferenceObjectData data = (entity as ReferenceObject)?.Data ?? entity as ReferenceObjectData;
#else
                ObjectReferenceObjectData data = (entity as ObjectReferenceObject)?.Data ?? entity as ObjectReferenceObjectData;
#endif
                if (data.GetType().Name == "ObjectReferenceObjectData" || data.GetType().Name == "ReferenceObjectData")
                {
                    EbxAssetEntry objBlueprint = App.AssetManager.GetEbxEntry(data.Blueprint.External.FileGuid);
                    if (objBlueprint != null)
                    {
                        EbxAsset objAsset = App.AssetManager.GetEbx(objBlueprint, false);
                        dynamic objRootAsset = objAsset.RootObject;

                        EbxAssetEntry objMeshAsset;

                        try
                        {
                            objMeshAsset = App.AssetManager.GetEbxEntry(objRootAsset.Object.Internal.Mesh.External.FileGuid);
                        }
                        catch { continue; }

                        if (objMeshAsset != null)
                        {
                            task.Update("Object " + objMeshAsset.DisplayName);

                            LinearTransform blueprintTransform = data.BlueprintTransform;
                            xmlWriter.WriteElementString("Blueprint", objBlueprint.Name);
                            WriteTransformToXML(xmlWriter, blueprintTransform);

                            string path = Path.Combine(meshPath, objBlueprint.DisplayName + "_mesh.fbx");

                            EbxAsset meshAssetEbx = App.AssetManager.GetEbx(objMeshAsset);
                            dynamic meshAsset = meshAssetEbx.RootObject;

                            if (!hasExportedMesh.TryGetValue(path, out var _))
                            {
                                ResAssetEntry res = App.AssetManager.GetResEntry(meshAsset.MeshSetResource);

                                exporter.ExportFBX(meshAsset, path, "2017", "Meters", false, true, string.Empty, "binary", App.AssetManager.GetResAs<MeshSetPlugin.Resources.MeshSet>(res));

                                MeshMaterialCollection materials = new MeshMaterialCollection(
                                    App.AssetManager.GetEbx(objMeshAsset),
                                    new PointerRef()
                                );

                                ulong resRid = meshAsset.MeshSetResource;
                                ResAssetEntry rEntry = App.AssetManager.GetResEntry(resRid);

                                var meshSet = App.AssetManager.GetResAs<MeshSetPlugin.Resources.MeshSet>(rEntry);
                                ExportParameters(materials, objMeshAsset, objBlueprint, texturePath, meshSet, xmlWriterMaterials);
                                WriteSectionsToXML(materials, xmlWriter, objMeshAsset, objBlueprint, meshSet);

                                hasExportedMesh[path] = true;
                            }

                            xmlWriter.WriteEndElement();
                            objCount++;
                            instanceCount++;
                        }
                    }
                }
            }

#if GW1
            foreach (object entity in objects.Where(e => e is SpatialReferenceObject || e is SpatialReferenceObjectData))
#else
            foreach (object entity in objects.Where(e => e is SpatialPrefabReferenceObject || e is SpatialPrefabReferenceObjectData))
#endif
            {
                xmlWriter.WriteStartElement("SpatialPrefabInstance");

#if GW1
                SpatialReferenceObjectData data = (entity as SpatialReferenceObject)?.Data ?? entity as SpatialReferenceObjectData;
#else
                SpatialPrefabReferenceObjectData data = (entity as SpatialPrefabReferenceObject)?.Data ?? entity as SpatialPrefabReferenceObjectData;
#endif

                EbxAssetEntry objBlueprint = App.AssetManager.GetEbxEntry(data.Blueprint.External.FileGuid);

                if (objBlueprint != null)
                {
                    EbxAsset asset = App.AssetManager.GetEbx(objBlueprint);
                    dynamic rootObject = asset.RootObject;

                    task.Update("SpatialPrefab " + objBlueprint.Name);

                    LinearTransform blueprintTransform = data.BlueprintTransform;

                    xmlWriter.WriteElementString("Blueprint", objBlueprint.Name);
                    WriteTransformToXML(xmlWriter, blueprintTransform);
                    xmlWriter.WriteEndElement();

                    objCount++;
                    instanceCount++;
                    spatialCount++;
                }
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteElementString("ObjectCount", instanceCount.ToString());
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
