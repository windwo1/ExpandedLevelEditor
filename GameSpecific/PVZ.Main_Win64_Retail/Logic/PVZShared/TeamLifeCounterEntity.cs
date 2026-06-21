using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TeamLifeCounterEntityData))]
	public class TeamLifeCounterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.TeamLifeCounterEntityData>
	{
		public new FrostySdk.Ebx.TeamLifeCounterEntityData Data => data as FrostySdk.Ebx.TeamLifeCounterEntityData;
		public override string DisplayName => "TeamLifeCounter";

		public TeamLifeCounterEntity(FrostySdk.Ebx.TeamLifeCounterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

