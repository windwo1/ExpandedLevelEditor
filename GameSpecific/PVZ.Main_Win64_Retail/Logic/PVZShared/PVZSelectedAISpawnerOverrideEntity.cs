using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSelectedAISpawnerOverrideEntityData))]
	public class PVZSelectedAISpawnerOverrideEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZSelectedAISpawnerOverrideEntityData>
	{
		public new FrostySdk.Ebx.PVZSelectedAISpawnerOverrideEntityData Data => data as FrostySdk.Ebx.PVZSelectedAISpawnerOverrideEntityData;
		public override string DisplayName => "PVZSelectedAISpawnerOverride";

		public PVZSelectedAISpawnerOverrideEntity(FrostySdk.Ebx.PVZSelectedAISpawnerOverrideEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

