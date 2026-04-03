using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIUnlockAssetObjectiveEntityData))]
	public class UIUnlockAssetObjectiveEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIUnlockAssetObjectiveEntityData>
	{
		public new FrostySdk.Ebx.UIUnlockAssetObjectiveEntityData Data => data as FrostySdk.Ebx.UIUnlockAssetObjectiveEntityData;
		public override string DisplayName => "UIUnlockAssetObjective";

		public UIUnlockAssetObjectiveEntity(FrostySdk.Ebx.UIUnlockAssetObjectiveEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

