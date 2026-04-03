using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.MissionGiverEntityData))]
	public class MissionGiverEntity : LogicEntity, IEntityData<FrostySdk.Ebx.MissionGiverEntityData>
	{
		public new FrostySdk.Ebx.MissionGiverEntityData Data => data as FrostySdk.Ebx.MissionGiverEntityData;
		public override string DisplayName => "MissionGiver";

		public MissionGiverEntity(FrostySdk.Ebx.MissionGiverEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

