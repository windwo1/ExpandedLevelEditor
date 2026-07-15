using Frosty.Controls;
using Frosty.Core;
using Frosty.Core.Controls;
using Frosty.Core.Viewport;
using Frosty.Core.Viewport.DXUT;
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
using Microsoft.CSharp.RuntimeBinder;
using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Matrix = SharpDX.Matrix;

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

        public static Vector3 GetPositionInFront(this BaseCamera cam, float distance)
        {
            var offset = new Vector3(0, -2, 0);

            Vector3 eye = cam.GetEyePt() * new Vector3(-1, 1, 1);
            Vector3 lookAt = cam.GetLookAtPt() * new Vector3(-1, 1, 1);
            Vector3 forward = lookAt - eye;
            forward.Normalize();

            return (eye + forward * distance) + offset;
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
                new RegularToolbarItem("Add Object", "Add a new object to this level", "LevelEditorPlugin/Images/Add.png", new RelayCommand((o) => AddEntityFromButton() )),
                new RegularToolbarItem("", "Duplicate the selected object", "LevelEditorPlugin/Images/Copy.png", new RelayCommand((o) => DuplicateEntity() )),
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

        private void AddEntityFromButton()
        {
            var window = new AddObjectWindow();
            window.Show();

            var pos = screen.camera.GetPositionInFront(distance: 8f);
            window.SelectedAsset += (s, e) => AddEntity(e.Asset, e.Count, Matrix.Translation(pos));
        }

        private void DuplicateEntity()
        {
            if (selectedEntity == null)
            {
                App.Logger.Log("Select an entity first to duplicate it");
                return;
            }

            int amount = 1;

            if (selectedEntity is ReferenceObject refObj)
            {
                var guid = refObj.Data.Blueprint.External.FileGuid;
                var transform = refObj.GetTransform();

                AddEntity(App.AssetManager.GetEbxEntry(guid), amount, transform, refObj.Layer);
                return;
            }
            else if (selectedEntity is StaticModelGroupElementEntity staticObj)
            {
                var guid = staticObj.Data.Blueprint.External.FileGuid;
                var transform = staticObj.GetTransform();

                AddEntity(App.AssetManager.GetEbxEntry(guid), amount, transform, staticObj.Layer, staticObj.Parent.Parent);
                return;
            }

            App.Logger.LogWarning("Cannot duplicate entity of type " + selectedEntity.GetType().Name);
        }

        private void AddEntity(EbxAssetEntry asset, int count, Matrix transform, SceneLayer addedLayer = null, Entities.Entity parentOverride = null)
        {
            int maxCount = count;

            FrostyTaskWindow.Show("Adding " + asset.DisplayName, "", (task) =>
            {
                while (count > 0)
                {
                    EbxAsset layerAsset = null;
                    Entities.Entity owner = null;
                    Entities.Entity parent = null;
                    SceneLayer layer = null;

                    if (addedLayer != null)
                    {
                        var entities = new List<Entities.Entity>();
                        addedLayer.CollectEntities(entities);

                        if (entities.Count != 0)
                        {
                            layerAsset = LoadedAssetManager.Instance.GetEbxAsset(entities[0].Owner.FileGuid);
                            owner = entities[0].Owner;
                            parent = entities[0].Parent;
                            layer = addedLayer;
                        }
                    }
                    else
                    {
                        var layers = new List<SceneLayer>();
                        RootLayer.CollectLayers(layers);

                        // get any layer of the level so we can add to it
                        foreach (var item in layers)
                        {
                            if (layerAsset != null && owner != null && parent != null && layer != null)
                                break;

                            if (item.LayerName == "static_instances" || !item.IsVisible)
                                continue;

                            var entities = new List<Entities.Entity>();
                            item.CollectEntities(entities);

                            foreach (Entities.Entity layerEntity in entities.Where(en => en is ReferenceObject))
                            {
                                layerAsset = LoadedAssetManager.Instance.GetEbxAsset(layerEntity.Owner.FileGuid);
                                owner = layerEntity.Owner;
                                parent = layerEntity.Parent;
                                layer = item;
                                break;
                            }
                        }
                    }

                    if (parentOverride != null)
                        parent = parentOverride;

                    if (layerAsset == null || owner == null || parent == null || layer == null)
                    {
                        App.Logger.LogError("Failed to find a layer to add to");
                        return;
                    }

                    string prefabName = asset.Name;

                    var prefabObj = CreateEntityData(typeof(ReferenceObjectData), layerAsset) as ReferenceObjectData;

                    layerAsset.AddObject(prefabObj);

                    var entity = new ReferenceObject(prefabObj, parent, world, CreateRef(prefabName, layerAsset));
                    if (parent is WorldPartReferenceObject obj)
                    {
                        obj.AddEntity(entity);
                    }
                    else if (parent is SubWorldReferenceObject subWorld)
                    {
                        subWorld.AddEntity(entity);
                    }

                    var originalOwner = entity.Owner;
                    entity.SetDefaultValues();
                    entity.SetTransform(transform, true);
                    entity.SetOwner(originalOwner);

#if !GW1
                    prefabObj.LightmapResolutionScale = 1;
#endif
#if !MASS_EFFECT && !SWBF2
                    prefabObj.CastSunShadowEnable = true;
                    prefabObj.CastReflectionEnable = true;
#if !GW1
                    prefabObj.CastEnvmapEnable = true;
#endif
#endif

                    layer.AddEntity(entity);
                    screen.AddEntity(entity, true);

                    try
                    {
                        // if flags aren't 1, it won't show up in game
                        ((dynamic)layerAsset.RootObject).Flags = 1; 
                    }
                    catch (RuntimeBinderException) { }

                    var layerEntry = App.AssetManager.GetEbxEntry(layerAsset.FileGuid);

                    App.AssetManager.ModifyEbx(layerEntry.Name, layerAsset);

                    count--;
                    task.Update($"{maxCount - count}/{maxCount}");
                }
            });
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
                else if (entity.Owner.Parent is SubWorldReferenceObject subWorld)
                {
                    subWorld.RemoveEntity(objEntity);
                }

                App.AssetManager.ModifyEbx(App.AssetManager.GetEbxEntry(layerAsset.FileGuid).Name, layerAsset);
                removed = true;
            }

            if (removed)
            {
                entity.Owner.Layer.RemoveEntity(entity.Owner);
                screen.RemoveEntity(entity.Owner);
                ClearSelection();
                return;
            }

            App.Logger.LogError($"Failed to delete entity of type {entity.Owner.GetType().Name}. Can only delete static models & prefabs for now.");
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
    }
}
