using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCommanderAbilityData))]
	public class PVZCommanderAbility : LogicEntity, IEntityData<FrostySdk.Ebx.PVZCommanderAbilityData>
	{
		public new FrostySdk.Ebx.PVZCommanderAbilityData Data => data as FrostySdk.Ebx.PVZCommanderAbilityData;
		public override string DisplayName => "PVZCommanderAbility";

		public PVZCommanderAbility(FrostySdk.Ebx.PVZCommanderAbilityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

