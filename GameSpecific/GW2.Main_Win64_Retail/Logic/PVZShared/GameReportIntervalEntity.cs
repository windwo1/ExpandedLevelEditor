using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.GameReportIntervalEntityData))]
	public class GameReportIntervalEntity : LogicEntity, IEntityData<FrostySdk.Ebx.GameReportIntervalEntityData>
	{
		public new FrostySdk.Ebx.GameReportIntervalEntityData Data => data as FrostySdk.Ebx.GameReportIntervalEntityData;
		public override string DisplayName => "GameReportInterval";

		public GameReportIntervalEntity(FrostySdk.Ebx.GameReportIntervalEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

