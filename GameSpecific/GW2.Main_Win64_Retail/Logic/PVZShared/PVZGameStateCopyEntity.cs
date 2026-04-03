using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZGameStateCopyEntityData))]
	public class PVZGameStateCopyEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZGameStateCopyEntityData>
	{
		public new FrostySdk.Ebx.PVZGameStateCopyEntityData Data => data as FrostySdk.Ebx.PVZGameStateCopyEntityData;
		public override string DisplayName => "PVZGameStateCopy";

		public PVZGameStateCopyEntity(FrostySdk.Ebx.PVZGameStateCopyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

