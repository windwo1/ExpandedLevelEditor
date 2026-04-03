using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.GameTrialStatusCheckData))]
	public class GameTrialStatusCheck : LogicEntity, IEntityData<FrostySdk.Ebx.GameTrialStatusCheckData>
	{
		public new FrostySdk.Ebx.GameTrialStatusCheckData Data => data as FrostySdk.Ebx.GameTrialStatusCheckData;
		public override string DisplayName => "GameTrialStatusCheck";

		public GameTrialStatusCheck(FrostySdk.Ebx.GameTrialStatusCheckData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

