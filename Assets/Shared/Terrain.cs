using Frosty.Core;
using Frosty.Core.Viewport;
using FrostySdk.Ebx;
using FrostySdk.Resources;
using LevelEditorPlugin.Render;
using LevelEditorPlugin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditorPlugin.Assets
{
    [AssetBinding(DataType = typeof(TerrainData))]
    public class Terrain : Asset, IAssetData<TerrainData>
    {
        public TerrainData Data => data as TerrainData;

        private Resources.TerrainStreamingTree terrainStreamingTree;

        private Resources.TerrainLayerCombinations terrainLayerCombinations;

        private Resources.VisualTerrain visualTerrain;

        public TerrainRenderable TerrainData { get; private set; }

        public int MaxLayerCount { get; private set; }

        public Terrain(Guid fileGuid, TerrainData inData)
            : base(fileGuid, inData)
        {
            terrainStreamingTree = App.AssetManager.GetResAs<Resources.TerrainStreamingTree>(App.AssetManager.GetResEntry((ulong)Data.TerrainStreamingTreeResource), null);
            visualTerrain = App.AssetManager.GetResAs<Resources.VisualTerrain>(App.AssetManager.GetResEntry((ulong)Data.VisualResource), null);
            MaxLayerCount = (int)(terrainStreamingTree.GetRasterTree(RasterTreeTypes.TerrainMaskTreeType) as TerrainMaskTree).maxLayerCount;
        }

        public void LoadResource(RenderCreateState state)
        {
            if (TerrainData == null)
            {
                TerrainData = new TerrainRenderable(state, terrainStreamingTree);
            }
        }

        public override void Dispose()
        {
            TerrainData.Dispose();
        }
    }
}
