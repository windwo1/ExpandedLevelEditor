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
using LevelEditorPlugin.Assets;
using LevelEditorPlugin.Entities;
using LevelEditorPlugin.Layers;
using LevelEditorPlugin.Managers;
using LevelEditorPlugin.Render;
using LevelEditorPlugin.Screens;
using MeshSetPlugin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using TexturePlugin;
using static System.Net.Mime.MediaTypeNames;

namespace LevelEditorPlugin.Editors
{
    public static class Utils
    {
        private static bool IsTypeValid(Type a, Type b)
        {
            return a == b || a.IsSubclassOf(b);
        }

        // This should only be used to obtain internal references or external IF the asset has already been loaded
        // through the LoadedAssetManager

        public static T GetObjectAs<T>(this PointerRef pr)
        {
            if (pr.Type == PointerRefType.External)
            {
                EbxAsset asset = LoadedAssetManager.Instance.GetEbxAsset(pr);
                Debug.Assert(asset != null, "Asset was not previously loaded via the LoadedAssetManager");

                dynamic obj = asset.GetObject(pr.External.ClassGuid);
                Debug.Assert(!(obj is Assets.Asset), "GetObjectAs should not be used on Assets");

                if (IsTypeValid(obj.GetType(), typeof(T)))
                    return (T)obj;
            }
            else if (pr.Type == PointerRefType.Internal)
            {
                if (IsTypeValid(pr.Internal.GetType(), typeof(T)))
                    return (T)pr.Internal;
            }

            return default(T);
        }

        public static Guid GetInstanceGuid(this PointerRef pr)
        {
            if (pr.Type == PointerRefType.Null)
                return Guid.Empty;

            else if (pr.Type == PointerRefType.Internal)
            {
                DataContainer container = pr.Internal as FrostySdk.Ebx.DataContainer;
                if (container.__InstanceGuid.IsExported)
                    return container.__InstanceGuid.ExportedGuid;

                return Guid.Parse(container.__InstanceGuid.ToString());
            }

            return pr.External.ClassGuid;
        }

        public static bool IsFieldProperty(string fieldName)
        {
            if (ProfilesLibrary.DataVersion == (int)ProfileVersion.MassEffectAndromeda)
            {
                Type extension = Type.GetType("LevelEditorPlugin.UtilsExtension");
                if (extension != null)
                {
                    return (bool)extension.GetMethod("IsFieldProperty", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[] { fieldName });
                }
            }
            return false;
        }
    }

    public class SelectedEntityChangedEventArgs : EventArgs
    {
        public Entities.Entity NewSelection { get; private set; }
        public Entities.Entity OldSelection { get; private set; }

        public SelectedEntityChangedEventArgs(Entities.Entity inNew, Entities.Entity inOld)
        {
            NewSelection = inNew;
            OldSelection = inOld;
        }
    }

    public class SelectedLayerChangedEventArgs : EventArgs
    {
        public Layers.SceneLayer NewSelection { get; private set; }
        public Layers.SceneLayer OldSelection { get; private set; }

        public SelectedLayerChangedEventArgs(Layers.SceneLayer inNew, Layers.SceneLayer inOld)
        {
            NewSelection = inNew;
            OldSelection = inOld;
        }
    }

    public class SelectedObjectChangedEventArgs : EventArgs
    {
        public object NewSelection { get; private set; }
        public object OldSelection { get; private set; }

        public SelectedObjectChangedEventArgs(object inNew, object inOld)
        {
            NewSelection = inNew;
            OldSelection = inOld;
        }
    }

    [TemplatePart(Name = PART_Renderer, Type = typeof(FrostyViewport))]
    public class LevelEditor : SpatialEditor
    {
        private const string PART_Renderer = "PART_Renderer";

        private FrostyViewport viewport;

        //static LevelEditor()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(LevelEditor), new FrameworkPropertyMetadata(typeof(LevelEditor)));
        //}

        public LevelEditor(ILogger inLogger)
            : base(inLogger)
        {
            screen = new LevelEditorScreen(false);
            dockManager.LoadFromConfig("LevelEditor", new Controls.DockManager.DockManagerConfigData()
            {
                Layouts = new List<Controls.DockManager.DockLayoutData>()
                {
                    new Controls.DockManager.DockLayoutData()
                    {
                        UniqueId = "UID_LevelEditor_Layers",
                        IsVisible = true,
                        IsSelected = true,
                        Location = Controls.DockLocation.TopLeft
                    },
                    new Controls.DockManager.DockLayoutData()
                    {
                        UniqueId = "UID_LevelEditor_Instances",
                        IsVisible = true,
                        IsSelected = true,
                        Location = Controls.DockLocation.BottomLeft
                    },
                    new Controls.DockManager.DockLayoutData()
                    {
                        UniqueId = "UID_LevelEditor_Properties",
                        IsVisible = true,
                        IsSelected = true,
                        Location = Controls.DockLocation.TopRight
                    },
                    new Controls.DockManager.DockLayoutData()
                    {
                        UniqueId = "UID_LevelEditor_Timeline",
                        IsVisible = false,
                        IsSelected = false,
                        Location = Controls.DockLocation.Bottom,
                    },
                    new Controls.DockManager.DockLayoutData()
                    {
                        UniqueId = "UID_LevelEditor_TerrainLayers",
                        IsVisible = true,
                        IsSelected = false,
                        Location = Controls.DockLocation.TopLeft
                    },
                    new Controls.DockManager.DockLayoutData()
                    {
                        UniqueId = "UID_LevelEditor_Schematics",
                        IsVisible = false,
                        IsSelected = false,
                        Location = Controls.DockLocation.Floating,
                        FloatingData = new Controls.DockManager.DockLayoutFloatingData()
                        {
                             Width = 800,
                             Height = 400
                        }
                    }
                }
            });
        }

        public override List<ToolbarItem> RegisterToolbarItems()
        {
            return new List<ToolbarItem>()
            {
                new DockingToolbarItem("", "Show/Hide layers tab", "Images/Layers.png", new RelayCommand((o) => DockManager.AddItem(((DockingToolbarItem)o).Location, new LayersViewModel(this))), DockManager, "UID_LevelEditor_Layers"),
                new DockingToolbarItem("", "Show/Hide instances tab", "Images/Instances.png", new RelayCommand((o) => DockManager.AddItem(((DockingToolbarItem)o).Location, new InstancesViewModel(this, selectedEntity))), DockManager, "UID_LevelEditor_Instances"),
                new DockingToolbarItem("", "Show/Hide properties tab", "Images/Properties.png", new RelayCommand((o) => DockManager.AddItem(((DockingToolbarItem)o).Location, new PropertiesViewModel(this, selectedEntity))), DockManager, "UID_LevelEditor_Properties"),
                new DockingToolbarItem("", "Show/Hide terrain layers tab", "Images/Terrain.png", new RelayCommand((o) => DockManager.AddItem(((DockingToolbarItem)o).Location, new TerrainLayersViewModel(this))), DockManager, "UID_LevelEditor_TerrainLayers"),
                new DockingToolbarItem("", "Show/Hide timeline editor", "Images/Timeline.png", new RelayCommand((o) => DockManager.AddItem(((DockingToolbarItem)o).Location, new TimelineViewModel(this))), DockManager, "UID_LevelEditor_Timeline"),
                new FloatingOnlyDockingToolbarItem("", "Show/Hide schematics editor", "Images/Schematics.png", new RelayCommand((o) => DockManager.AddItem(((DockingToolbarItem)o).Location, new SchematicsViewModel(this, rootLayer))), DockManager, "UID_LevelEditor_Schematics"),
                new RegularToolbarItem("", "Export all visible instances to XML", "LevelEditorPlugin/Images/XMLFile.png", new RelayCommand((o) => { ExportLevel(); }))
            };
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            viewport = GetTemplateChild(PART_Renderer) as FrostyViewport;
            viewport.Screen = screen;
        }

        public override void Closed()
        {
            DockManager.SaveToConfig("LevelEditor");
            viewport.Shutdown();

            base.Closed();
        }

        protected override void Initialize()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            LoadedAssetManager.FailedAssets = 0;

            // first time loading stuff goes here
            FrostyTaskWindow.Show($"Loading {Path.GetFileName(AssetEntry.Name)}", "", (task) =>
            {
                currentLoadingState = new LoadingStateInfo()
                {
                    Task = task,
                    Logger = logger
                };

                if (!MeshVariationDb.IsLoaded)
                {
                    MeshVariationDb.LoadVariations(task);
                }
                MeshVariationDb.LoadModifiedVariations();

                world = new EntityWorld();
                WorldReferenceObject refObj = new Entities.WorldReferenceObject(Asset.FileGuid, RootObject as WorldData, asset, world);

                rootLayer = refObj.GetLayer();

                viewport.SetPaused(true);
                screen.AddEntity(refObj);
                screen.ShowTaskWindow = true;
                viewport.SetPaused(false);

                editingWorld = refObj;
                currentLoadingState = null;

                world.Initialize();
            });

            timer.Stop();

            if (LoadedAssetManager.FailedAssets > 0)
            {
                logger.LogWarning("Failed to create {0} assets, their AssetData was null! This shouldn't affect anything too much.", LoadedAssetManager.FailedAssets);
            }
            
            logger.Log($"Level loaded in {timer.Elapsed.ToString()}");

            DockManager.AddItemOnLoad(new LayersViewModel(this));
            DockManager.AddItemOnLoad(new InstancesViewModel(this, null));
            DockManager.AddItemOnLoad(new PropertiesViewModel(this, editingWorld));
            DockManager.AddItemOnLoad(new TimelineViewModel(this));
            DockManager.AddItemOnLoad(new TerrainLayersViewModel(this));
            DockManager.AddItemOnLoad(new SchematicsViewModel(this, rootLayer));
        }

        public void ExportLevel()
        {
            List<SceneLayer> layers = new List<SceneLayer>();
            RootLayer.CollectLayers(layers);

            //App.Logger.Log("Exporting {0} static model instances", entities.Count());
            string rootLayerName = RootLayer.LayerName;
            FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().FullName);

            string basePath = Path.Combine(Environment.CurrentDirectory, "Levels", rootLayerName);

            string meshPath = Path.Combine(basePath, "Meshes");
            string terrainPath = Path.Combine(basePath, "TerrainChunks");
            string texturePath = Path.Combine(basePath, "Textures");

            Directory.CreateDirectory(basePath);
            Directory.CreateDirectory(meshPath);
            Directory.CreateDirectory(terrainPath);
            Directory.CreateDirectory(texturePath);

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

                task.Update("Writing XML");
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = true,
                };
                XmlWriter xmlWriter = XmlWriter.Create(Path.Combine(basePath, rootLayerName) + ".xml", settings);
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

                        xmlWriter.WriteStartElement("StaticModelInstances");

                        int count = 0;
                        foreach (Entities.Entity entity in entities.Where((Entities.Entity e) => e is StaticModelGroupElementEntity))
                        {
                            xmlWriter.WriteStartElement("StaticModelGroupElementEntity");

                            StaticModelGroupElementEntity smi = entity as StaticModelGroupElementEntity;

                            //Get required assets (Object blueprint, mesh asset)
                            EbxAssetEntry objBlueprint = App.AssetManager.GetEbxEntry(smi.Data.Blueprint.External.FileGuid);

                            if (objBlueprint == null)
                                continue;

                            EbxAsset objAsset = App.AssetManager.GetEbx(objBlueprint);

                            dynamic objRootAsset = objAsset.RootObject;

                            EbxAssetEntry objMeshAsset = App.AssetManager.GetEbxEntry((objRootAsset.Object.Internal).Mesh.External.FileGuid);

                            string path = Path.Combine(meshPath, objBlueprint.DisplayName + "_mesh.fbx");

                            EbxAsset meshAssetEbx = App.AssetManager.GetEbx(objMeshAsset);
                            dynamic meshAsset = (dynamic)meshAssetEbx.RootObject;

                            if (!hasExportedMesh.TryGetValue(path, out var _))
                            {
                                if (objMeshAsset == null)
                                    continue;

                                //Update task

                                task.Update("StaticModel " + objMeshAsset.DisplayName);

                                //App.Logger.Log("{0}: {1}", objMeshAsset.DisplayName, smiTransform.ToString());

                                ResAssetEntry res = App.AssetManager.GetResEntry(meshAsset.MeshSetResource);

                                exporter.ExportFBX(meshAsset, path, "2017", "Meters", false, true, string.Empty, "binary", App.AssetManager.GetResAs<MeshSetPlugin.Resources.MeshSet>(res));

                                hasExportedMesh[path] = true;
                            }

                            ulong resRid = meshAsset.MeshSetResource;
                            ResAssetEntry rEntry = App.AssetManager.GetResEntry(resRid);

                            var meshSet = App.AssetManager.GetResAs<MeshSetPlugin.Resources.MeshSet>(rEntry);

                            ExportParameters(objMeshAsset, texturePath, meshSet, xmlWriterMaterials);

                            LinearTransform transform = smi.Data.Transform;

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
                        foreach (Entities.Entity entity in entities.Where((Entities.Entity e) => e is ObjectReferenceObject))
                        {
                            xmlWriter.WriteStartElement("ObjectInstance");
                            ObjectReferenceObject obj = entity as ObjectReferenceObject;

                            if (obj.Data.GetType().Name == "ObjectReferenceObjectData")
                            {
                                ObjectReferenceObjectData data = obj.Data;

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

                                            hasExportedMesh[path] = true;
                                        }

                                        ulong resRid = meshAsset.MeshSetResource;
                                        ResAssetEntry rEntry = App.AssetManager.GetResEntry(resRid);

                                        var meshSet = App.AssetManager.GetResAs<MeshSetPlugin.Resources.MeshSet>(rEntry);

                                        ExportParameters(objMeshAsset, texturePath, meshSet, xmlWriterMaterials);

                                        xmlWriter.WriteEndElement();
                                        objCount++;
                                        instanceCount++;
                                    }
                                }
                            }
                        }

                        foreach (Entities.Entity entity in entities.Where((Entities.Entity e) => e is SpatialPrefabReferenceObject))
                        {
                            xmlWriter.WriteStartElement("SpatialPrefabInstance");

                            SpatialPrefabReferenceObject spatial = entity as SpatialPrefabReferenceObject;
                            SpatialPrefabReferenceObjectData data = spatial.Data;

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
                        xmlWriter.WriteEndElement();
                    }
                }

                xmlWriter.WriteEndElement();
                xmlWriterMaterials.WriteEndElement();

                xmlWriter.Dispose();
                xmlWriterMaterials.Dispose();
                #endregion

                List<Entities.Entity> entityList = new List<Entities.Entity>();

                RootLayer.CollectEntities(entityList);
                foreach (Entities.Entity entity in entityList)
                {
                    if (entity is TerrainEntity)
                    {
                        task.Update("Exporting Terrain", null);

                        TerrainEntity terrainEntity = entity as TerrainEntity;

                        int index = 0;

                        foreach (TerrainChunkRenderable terrainChunk in terrainEntity.Terrain.TerrainData.TerrainChunks)
                        {
                            terrainChunk.ExportToOBJ(Path.Combine(terrainPath, $"chunk_{terrainChunk.Level}_{index}.obj"));
                            index++;
                        }
                    }
                }

                timer.Stop();

                App.Logger.Log("Exported {0} static models, {1} objects, {2} spatialprefabs in {3}", smiCount, objCount, spatialCount, timer.Elapsed);
            });
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

        private TextureExporter textureExporter = new TextureExporter();

        private void ExportParameters(EbxAssetEntry meshAssetEbx, string path, MeshSetPlugin.Resources.MeshSet meshSet, XmlWriter xmlWriter)
        {
            try
            {
                MeshMaterialCollection materials = new MeshMaterialCollection(
                    App.AssetManager.GetEbx(meshAssetEbx),
                    new PointerRef()
                    );

                xmlWriter.WriteStartElement("Material");
                xmlWriter.WriteElementString("Name", meshAssetEbx.Name);

                for (int i = 0; i < materials.Count; i++)
                {
                    var material = materials[i];
                    var section = meshSet.Lods[0].Sections[i];

                    xmlWriter.WriteStartElement("Material");
                    xmlWriter.WriteElementString("Name", section.Name);

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
                App.Logger.LogError("Failed to get a texture or vector paramater. Failed Asset: " + meshAssetEbx.Name + ". Exception: " + ex.Message.ToString());
            }
        }

        public MeshSetPlugin.Resources.LinearTransform EbxTransformToMSPTransform(FrostySdk.Ebx.LinearTransform EbxLt)
        {
            MeshSetPlugin.Resources.LinearTransform meshLt = new MeshSetPlugin.Resources.LinearTransform();
            MeshSetPlugin.Resources.Vec3 frwd = new MeshSetPlugin.Resources.Vec3();
            MeshSetPlugin.Resources.Vec3 right = new MeshSetPlugin.Resources.Vec3();
            MeshSetPlugin.Resources.Vec3 up = new MeshSetPlugin.Resources.Vec3();
            MeshSetPlugin.Resources.Vec3 trans = new MeshSetPlugin.Resources.Vec3();

            frwd.x = EbxLt.forward.x;
            frwd.y = EbxLt.forward.y;
            frwd.z = EbxLt.forward.z;

            right.x = EbxLt.right.x;
            right.y = EbxLt.right.y;
            right.z = EbxLt.right.z;

            up.x = EbxLt.up.x;
            up.y = EbxLt.up.y;
            up.z = EbxLt.up.z;

            trans.x = EbxLt.trans.x;
            trans.y = EbxLt.trans.y;
            trans.z = EbxLt.trans.z;

            meshLt.forward = frwd;
            meshLt.right = right;
            meshLt.up = up;
            meshLt.trans = trans;

            return meshLt;
        }
    }
}
