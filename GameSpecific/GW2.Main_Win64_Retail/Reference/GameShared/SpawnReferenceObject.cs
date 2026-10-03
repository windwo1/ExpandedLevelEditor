using Frosty.Core.Viewport;
using LevelEditorPlugin.Managers;
using LevelEditorPlugin.Render;
using LevelEditorPlugin.Render.Proxies;
using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SpawnReferenceObjectData))]
	public class SpawnReferenceObject : SpatialReferenceObject, IEntityData<FrostySdk.Ebx.SpawnReferenceObjectData>
	{
		public new FrostySdk.Ebx.SpawnReferenceObjectData Data => data as FrostySdk.Ebx.SpawnReferenceObjectData;

        public ObjRenderable MeshData { get; private set; }

        public override bool RequiresTransformUpdate { get => requiresTransformUpdate; set => requiresTransformUpdate = value; }

        protected bool requiresTransformUpdate;

        public SpawnReferenceObject(FrostySdk.Ebx.SpawnReferenceObjectData inData, Entity inParent)
			: base(inData, inParent)
		{
		}

        public override void CreateRenderProxy(List<RenderProxy> proxies, RenderCreateState state)
        {
            if (!Data.Enabled || !Data.UseAsSpawnPoint) // for now we just want player spawns
                return;

            MeshData = LoadedMeshManager.Instance.LoadMesh(state, "Sprite");
            proxies.Add(new SpriteRenderProxy(state, this, MeshData, "Spawn"));

            SetFlags(EntityFlags.RenderProxyGenerated);
        }

        public override void Destroy()
        {
            LoadedMeshManager.Instance.UnloadMesh(MeshData);
        }
    }
}

