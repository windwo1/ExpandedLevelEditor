using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.OfflineGameReportTriggerEntityData))]
	public class OfflineGameReportTriggerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.OfflineGameReportTriggerEntityData>
	{
		public new FrostySdk.Ebx.OfflineGameReportTriggerEntityData Data => data as FrostySdk.Ebx.OfflineGameReportTriggerEntityData;
		public override string DisplayName => "OfflineGameReportTrigger";

		public OfflineGameReportTriggerEntity(FrostySdk.Ebx.OfflineGameReportTriggerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

