using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITrialModeEntityData))]
	public class UITrialModeEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UITrialModeEntityData>
	{
		public new FrostySdk.Ebx.UITrialModeEntityData Data => data as FrostySdk.Ebx.UITrialModeEntityData;
		public override string DisplayName => "UITrialMode";

		public UITrialModeEntity(FrostySdk.Ebx.UITrialModeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

