using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AnimatedPointCloudEntityData))]
	public class AnimatedPointCloudEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AnimatedPointCloudEntityData>
	{
		public new FrostySdk.Ebx.AnimatedPointCloudEntityData Data => data as FrostySdk.Ebx.AnimatedPointCloudEntityData;
		public override string DisplayName => "AnimatedPointCloud";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public AnimatedPointCloudEntity(FrostySdk.Ebx.AnimatedPointCloudEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

