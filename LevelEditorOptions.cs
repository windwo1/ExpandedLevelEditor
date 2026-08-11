using Frosty.Core;
using FrostySdk.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditorPlugin
{
    [DisplayName("Level Editor Options")]
    public class LevelEditorOptions : OptionsExtension
    {
        [Category("Editors")]
        [DisplayName("Level Editor Enabled")]
        [Description("Enables the Level Editor for assets of type 'LevelData'")]
        public bool LevelEditorEnabled { get; set; } = true;

        [Category("Editors")]
        [DisplayName("Detached SubWorld Editor Enabled")]
        [Description("Enables the Detached SubWorld Editor for assets of type 'DetachedSubWorldData'")]
        public bool SubWorldEditorEnabled { get; set; } = false;

        [Category("Editors")]
        [DisplayName("Object Blueprint Editor Enabled")]
        [Description("Enables the Object Blueprint Editor for assets of type 'ObjectBlueprint'")]
        public bool ObjectBlueprintEditorEnabled { get; set; } = false;

        [Category("Editors")]
        [DisplayName("Logic Prefab Editor Enabled")]
        [Description("Enables the Logic Prefab Editor for assets of type 'LogicPrefabBlueprint'")]
        public bool LogicPrefabEditorEnabled { get; set; } = false;

        [Category("Editors")]
        [DisplayName("Spatial Prefab Editor Enabled")]
        [Description("Enables the Spatial Prefab Editor for assets of type 'SpatialPrefabBlueprint'")]
        public bool SpatialPrefabEditorEnabled { get; set; } = true;
        [Category("Editor Options")]
        [DisplayName("Manage Bundles For Objects")]
        [Description("Automatically assigns the bundles from the layer asset to all dependencies of the added objects, including Res/Chunks. Can sometimes crash the game, the Bundle Manager is experimental")]
        public bool BundleManagerEnabled { get; set; } = false;
        [Category("Exporting")]
        [DisplayName("Mesh LOD")]
        [Description("The LOD (Level Of Detail) that will be exported for each mesh. If the selected LOD is higher than the max LOD of a mesh, it will export whatever is the highest LOD")]
        public int LODIndex { get; set; } = 0;

        [Category("Exporting")]
        [DisplayName("Export Prefabs")]
        [Description("Whether Spatial Prefab Blueprints will be included in your export. Can make exports smaller if this is off")]
        public bool ExportPrefabs { get; set; } = true;

        [Category("Exporting")]
        [DisplayName("Use Alpha")]
        [Description("Whether the alpha of Color/Diffuse textures will be used when importing to Blender")]
        public bool UseAlpha { get; set; } = true;

#if !GW1
        [Category("Exporting")]
        [DisplayName("Use Emission")]
        [Description("Whether emission from ETT textures will be used when importing to Blender. Can be inaccurate")]
        public bool UseEmission { get; set; } = false;
#endif
        [Category("Exporting")]
        [DisplayName("Terrain Decimation")]
        [Description("The decimation value that will be used on terrain in Blender when importing, no decimation = 1. This can sometimes leave seams/gaps in the terrain")]
        public float TerrainDecimation { get; set; } = 0.05f;

        public override void Load()
        {
            LevelEditorEnabled = Config.Get<bool>("LevelEditorEnabled", true);
            SubWorldEditorEnabled = Config.Get<bool>("SubWorldEditorEnabled", false);
            ObjectBlueprintEditorEnabled = Config.Get<bool>("ObjectBlueprintEditorEnabled", false);
            LogicPrefabEditorEnabled = Config.Get<bool>("LogicPrefabEditorEnabled", false);
            SpatialPrefabEditorEnabled = Config.Get<bool>("SpatialPrefabEditorEnabled", true);

            BundleManagerEnabled = Config.Get<bool>("BundleManagerEnabled", true);

            LODIndex = Config.Get<int>("LODIndex", 0);
            ExportPrefabs = Config.Get<bool>("ExportPrefabs", true);
            UseAlpha = Config.Get<bool>("UseAlpha", true);
#if !GW1
            UseEmission = Config.Get<bool>("UseEmission", false);
#endif
            TerrainDecimation = Config.Get<float>("TerrainDecimation", 0.05f);
        }

        public override void Save()
        {
            Config.Add("LevelEditorEnabled", LevelEditorEnabled);
            Config.Add("SubWorldEditorEnabled", SubWorldEditorEnabled);
            Config.Add("ObjectBlueprintEditorEnabled", ObjectBlueprintEditorEnabled);
            Config.Add("LogicPrefabEditorEnabled", LogicPrefabEditorEnabled);
            Config.Add("SpatialPrefabEditorEnabled", SpatialPrefabEditorEnabled);

            Config.Add("BundleManagerEnabled", BundleManagerEnabled);

            Config.Add("LODIndex", LODIndex);
            Config.Add("ExportPrefabs", ExportPrefabs);
            Config.Add("UseAlpha", UseAlpha);
#if !GW1
            Config.Add("UseEmission", UseEmission);
#endif
            Config.Add("TerrainDecimation", TerrainDecimation);

            Config.Save();
        }
    }
}
