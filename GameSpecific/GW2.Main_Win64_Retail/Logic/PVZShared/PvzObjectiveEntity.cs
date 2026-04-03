using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PvzObjectiveEntityData))]
	public class PvzObjectiveEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PvzObjectiveEntityData>
	{
		public new FrostySdk.Ebx.PvzObjectiveEntityData Data => data as FrostySdk.Ebx.PvzObjectiveEntityData;
		public override string DisplayName => "PvzObjective";

		public PvzObjectiveEntity(FrostySdk.Ebx.PvzObjectiveEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

