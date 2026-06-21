using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AnimatedTransformEntityData))]
	public class AnimatedTransformEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AnimatedTransformEntityData>
	{
		public new FrostySdk.Ebx.AnimatedTransformEntityData Data => data as FrostySdk.Ebx.AnimatedTransformEntityData;
		public override string DisplayName => "AnimatedTransform";

		public AnimatedTransformEntity(FrostySdk.Ebx.AnimatedTransformEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

