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
using LevelEditorPlugin.Assets;
using LevelEditorPlugin.Entities;
using LevelEditorPlugin.Layers;
using LevelEditorPlugin.Managers;
using LevelEditorPlugin.Screens;
using LevelEditorPlugin.Windows;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

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

        private const float DeletedEntityPos = 999999f;

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
                new RegularToolbarItem("", "Export all visible instances to XML", "LevelEditorPlugin/Images/XMLFile.png", new RelayCommand((o) => ExportLevel() )),
                new DividerToolbarItem(),
                new RegularToolbarItem("Add Object", "Add a new object to this level", "LevelEditorPlugin/Images/Add.png", new RelayCommand((o) => AddEntity() ))
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

            LoadedAssetManager.Instance.FailedAssets = 0;

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

                //world.Initialize();
            });

            timer.Stop();

            if (LoadedAssetManager.Instance.FailedAssets > 0)
            {
                logger.LogWarning("Failed to create {0} assets, their AssetData was null! This shouldn't affect anything too much.", LoadedAssetManager.Instance.FailedAssets);
            }
            
            logger.Log($"Level loaded in {timer.Elapsed}");

            DockManager.AddItemOnLoad(new LayersViewModel(this));
            DockManager.AddItemOnLoad(new InstancesViewModel(this, null));
            DockManager.AddItemOnLoad(new PropertiesViewModel(this, editingWorld));
            DockManager.AddItemOnLoad(new TimelineViewModel(this));
            DockManager.AddItemOnLoad(new TerrainLayersViewModel(this));
            DockManager.AddItemOnLoad(new SchematicsViewModel(this, rootLayer));

            screen.OnKeyUp += Screen_OnKeyUp;
        }

        private void Screen_OnKeyUp(object sender, OnKeyUpEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    DeleteEntity(e.Entity);
                    break;
            }
        }

        private void AddEntity()
        {
            var window = new AddObjectWindow();
            window.Show();

            window.SelectedAsset += (s, e) =>
            {
                Vector3 pos = GetPositionInFront(distance: 10f);

                if (e.Asset.Type == "ObjectBlueprint")
                {
                    // todo
                }
                else
                {
                    // spatial prefab
                    EbxAsset layerAsset = null;
                    Entities.Entity owner = null;
                    Entities.Entity parent = null;
                    SceneLayer layer = null;

                    var layers = new List<SceneLayer>();
                    RootLayer.CollectLayers(layers);

                    foreach (var item in layers)
                    {
                        if (layerAsset != null && owner != null && parent != null && layer != null)
                            break;

                        if (item.LayerName != "static_instances")
                        {
                            var entities = new List<Entities.Entity>();
                            item.CollectEntities(entities);

                            foreach (Entities.Entity layerEntity in entities.Where((Entities.Entity en) => en is SpatialPrefabReferenceObject))
                            {
                                layerAsset = LoadedAssetManager.Instance.GetEbxAsset(layerEntity.Owner.FileGuid);
                                owner = layerEntity.Owner;
                                parent = layerEntity.Parent;
                                layer = item;
                                break;
                            }
                        }
                    }

                    if (layerAsset == null || owner == null || parent == null || layer == null)
                        return;

                    dynamic layerObj = layerAsset.RootObject;

                    var spatialRefObj = CreateEntityData(typeof(SpatialPrefabReferenceObjectData), layerAsset) as SpatialPrefabReferenceObjectData;

                    layerAsset.AddObject(spatialRefObj);
                    PointerRef spatialRef = new PointerRef(internalRef: spatialRefObj);

                    var transform = Entities.Entity.MakeLinearTransform(Matrix.Translation(pos));

                    var entity = new SpatialPrefabReferenceObject(spatialRefObj, parent, world);
                    if (parent is WorldPartReferenceObject obj)
                    {
                        obj.AddEntity(entity);
                    }

                    entity.SetDefaultValues();
                    entity.SetTransform(Matrix.Translation(pos), true);
                    entity.GetLayer();

                    entity.Data.Blueprint = CreateRef(e.Asset.Name, layerAsset);
                    entity.Data.LightmapResolutionScale = 1;
                    entity.Data.CastSunShadowEnable = true;
                    entity.Data.CastReflectionEnable = true;
                    entity.Data.CastEnvmapEnable = true;
                    entity.Data.Excluded = true;
                    entity.Data.LocalPlayerId = LocalPlayerId.LocalPlayerId_Invalid;

                    App.AssetManager.ModifyEbx(App.AssetManager.GetEbxEntry(layerAsset.FileGuid).Name, layerAsset);

                    layer.AddEntity(entity);
                    screen.AddEntity(entity);
                    screen.SelectEntity(entity);
                }
            };
        }

        private void DeleteEntity(Entities.Entity entity)
        {
            var result = FrostyMessageBox.Show("Are you sure you want to delete the selected entity?", "Level Editor", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
                return;

            bool removed = false;
            if (entity.Owner is StaticModelGroupElementEntity staticEntity)
            {
                // don't know of a simple way of deleting a static model so this'll have to do for now
                var matrix = staticEntity.GetTransform();
                matrix.TranslationVector = new Vector3(DeletedEntityPos, DeletedEntityPos, DeletedEntityPos);

                staticEntity.SetTransform(matrix, true);
                (staticEntity.Parent as StaticModelGroupEntity).UpdateData(staticEntity);

                removed = true;
            }
            else if (entity.Owner is ReferenceObject objEntity)
            {
                var layerAsset = LoadedAssetManager.Instance.GetEbxAsset(objEntity.Owner.FileGuid);
                layerAsset.RemoveObject(objEntity);

                if (entity.Owner.Parent is WorldPartReferenceObject worldPart)
                {
                    worldPart.RemoveEntity(objEntity);
                }

                App.AssetManager.ModifyEbx(App.AssetManager.GetEbxEntry(layerAsset.FileGuid).Name, layerAsset);
                removed = true;
            }

            if (removed)
            {
                entity.Owner.Layer.RemoveEntity(entity);

                screen.RemoveEntity(entity);
                ClearSelection();
                return;
            }

            App.Logger.LogError("Failed to delete entity of type " + entity.Owner.GetType().Name);
        }

        private object CreateEntityData(Type entityDataType, EbxAsset asset)
        {
            DataBusPeer data = Activator.CreateInstance(entityDataType) as DataBusPeer;

            Guid guid = FrostySdk.Utils.GenerateDeterministicGuid(asset.Objects, entityDataType.Name, asset.FileGuid);
            data.SetInstanceGuid(new AssetClassGuid(guid, -1));

            byte[] array = guid.ToByteArray();
            uint flags = (uint)((int)(array[3] & 0x01) << 24 | (int)array[2] << 16 | (int)array[1] << 8 | (int)array[0]);

            data.Flags = flags;
            return data;
        }

        private PointerRef CreateRef(string assetPath, EbxAsset asset)
        {
            EbxAssetEntry entry = App.AssetManager.GetEbxEntry(assetPath);
            EbxAsset refAsset = App.AssetManager.GetEbx(entry);

            asset.AddDependency(entry.Guid);

            return new PointerRef(new EbxImportReference()
            {
                FileGuid = entry.Guid,
                ClassGuid = refAsset.RootInstanceGuid
            });
        }

        private Vector3 GetPositionInFront(float distance)
        {
            var cam = screen.camera;

            Vector3 eye = cam.GetEyePt();
            Vector3 lookAt = cam.GetLookAtPt();

            Vector3 forward = lookAt - eye;
            forward.Normalize();

            Vector3 right = Vector3.Cross(Vector3.UnitY, forward);
            right.Normalize();

            Vector3 up = Vector3.Cross(forward, right);

            return eye + forward * distance + right * 1.0f + up * 0.5f;
        }
    }
}
