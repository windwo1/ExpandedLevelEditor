using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PrioritizeTargetEntityData))]
	public class PrioritizeTargetEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PrioritizeTargetEntityData>
	{
		public new FrostySdk.Ebx.PrioritizeTargetEntityData Data => data as FrostySdk.Ebx.PrioritizeTargetEntityData;
		public override string DisplayName => "PrioritizeTarget";

		public PrioritizeTargetEntity(FrostySdk.Ebx.PrioritizeTargetEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

