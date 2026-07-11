using System.IO;
using FrostySdk.Ebx;
using LevelEditorPlugin.Assets;
using LevelEditorPlugin.Layers;
using SharpDX;

namespace LevelEditorPlugin.Entities
{
    [EntityBinding(DataType = typeof(WorldPartReferenceObjectData))]
    public class WorldPartReferenceObject : ReferenceObject, IEntityData<WorldPartReferenceObjectData>, ILayerEntity
    {
        public new WorldPartReferenceObjectData Data
        {
            get
            {
                GameObjectData obj = data;
                return (WorldPartReferenceObjectData)(object)((obj is WorldPartReferenceObjectData) ? obj : null);
            }
        }

        public new WorldPart Blueprint => blueprint as WorldPart;

        public WorldPartReferenceObject(WorldPartReferenceObjectData inData, Entity inParent)
            : base((ReferenceObjectData)(object)inData, inParent)
        {
        }

        public override void AddEntity(Entity inEntity)
        {
            inEntity.SetParent(this);
            (Blueprint.Data).Objects.Add(new PointerRef(inEntity.GetRawData()));
            entities.Add(inEntity);
        }

        public override void RemoveEntity(Entity inEntity)
        {
            (Blueprint.Data).Objects.Remove(new PointerRef(inEntity.GetRawData()));
        }

        public SceneLayer GetLayer()
        {
            //IL_0045: Unknown result type (might be due to invalid IL or missing references)
            if (blueprint == null)
            {
                return null;
            }

            string layerName = Path.GetFileName(blueprint.Name) ?? "";
            SceneLayer sceneLayer = new SceneLayer((Entity)this, layerName, (Color4?)new Color4(1f, 0f, 0f, 1f));
            foreach (Entity entity in entities)
            {
                if (entity is ILayerEntity)
                {
                    ILayerEntity layerEntity = entity as ILayerEntity;
                    SceneLayer layer = layerEntity.GetLayer();
                    if (layer != null)
                    {
                        sceneLayer.ChildLayers.Add(layer);
                    }
                }
                else
                {
                    sceneLayer.AddEntity(entity);
                    entity.SetOwner(entity);
                }
            }

            return sceneLayer;
        }
    }
}