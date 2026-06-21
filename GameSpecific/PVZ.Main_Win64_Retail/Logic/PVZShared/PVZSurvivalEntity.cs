using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSurvivalEntityData))]
	public class PVZSurvivalEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZSurvivalEntityData>
	{
		public new FrostySdk.Ebx.PVZSurvivalEntityData Data => data as FrostySdk.Ebx.PVZSurvivalEntityData;
		public override string DisplayName => "PVZSurvival";

		public PVZSurvivalEntity(FrostySdk.Ebx.PVZSurvivalEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

