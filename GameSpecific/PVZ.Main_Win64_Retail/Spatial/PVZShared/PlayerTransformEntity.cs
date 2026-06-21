using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PlayerTransformEntityData))]
	public class PlayerTransformEntity : GameComponentEntity, IEntityData<FrostySdk.Ebx.PlayerTransformEntityData>
	{
		public new FrostySdk.Ebx.PlayerTransformEntityData Data => data as FrostySdk.Ebx.PlayerTransformEntityData;

		public PlayerTransformEntity(FrostySdk.Ebx.PlayerTransformEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

