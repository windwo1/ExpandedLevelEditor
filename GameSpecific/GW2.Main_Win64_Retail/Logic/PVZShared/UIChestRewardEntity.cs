using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIChestRewardEntityData))]
	public class UIChestRewardEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIChestRewardEntityData>
	{
		public new FrostySdk.Ebx.UIChestRewardEntityData Data => data as FrostySdk.Ebx.UIChestRewardEntityData;
		public override string DisplayName => "UIChestReward";

		public UIChestRewardEntity(FrostySdk.Ebx.UIChestRewardEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

