using Frosty.Core.Viewport;
using FrostySdk.Ebx;
using LevelEditorPlugin.Editors;
using SharpDX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditorPlugin.Entities
{
    [EntityBinding(DataType = typeof(FrostySdk.Ebx.SpatialReferenceObjectData))]
    public class SpatialReferenceObject : ReferenceObject, IEntityData<FrostySdk.Ebx.SpatialReferenceObjectData>
    {
        public new FrostySdk.Ebx.SpatialReferenceObjectData Data => data as FrostySdk.Ebx.SpatialReferenceObjectData;
        protected Entity RootEntity => (entities.Count > 0) ? entities[0] : null;

        public SpatialReferenceObject(FrostySdk.Ebx.SpatialReferenceObjectData inData, Entity inParent, EntityWorld inWorld)
            : base(inData, inParent, inWorld)
        {
        }

        public SpatialReferenceObject(FrostySdk.Ebx.SpatialReferenceObjectData inData, Entity inParent)
            : base(inData, inParent)
        {
        }

        protected override void SpawnEntities()
        {
            base.SpawnEntities();
            SpawnComponents();
        }

        protected virtual void SpawnComponents()
        {
            if (Blueprint != null)
            {
                if (Parent == null || RootEntity is IAllowComponentsInLevel)
                {

                    if (RootEntity is IComponentEntity)
                    {
                        IComponentEntity componentEntity = RootEntity as IComponentEntity;
                        componentEntity.SpawnComponents();
                    }
                }
            }
        }

        public Layers.SceneLayer GetLayer()
        {
            if (blueprint == null)
                return null;

            string layerName = Path.GetFileName(blueprint.Name);
            Layers.SceneLayer layer = new Layers.SceneLayer(this, layerName, new SharpDX.Color4(0.0f, 0.5f, 0.0f, 1.0f));

            foreach (Entity entity in entities)
            {
                if (entity is ILayerEntity)
                {
                    ILayerEntity entityLayer = entity as ILayerEntity;
                    Layers.SceneLayer childLayer = entityLayer.GetLayer();
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
    }
}
