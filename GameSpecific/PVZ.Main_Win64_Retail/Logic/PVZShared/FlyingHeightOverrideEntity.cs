using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.FlyingHeightOverrideEntityData))]
	public class FlyingHeightOverrideEntity : LogicEntity, IEntityData<FrostySdk.Ebx.FlyingHeightOverrideEntityData>
	{
		public new FrostySdk.Ebx.FlyingHeightOverrideEntityData Data => data as FrostySdk.Ebx.FlyingHeightOverrideEntityData;
		public override string DisplayName => "FlyingHeightOverride";

		public FlyingHeightOverrideEntity(FrostySdk.Ebx.FlyingHeightOverrideEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

