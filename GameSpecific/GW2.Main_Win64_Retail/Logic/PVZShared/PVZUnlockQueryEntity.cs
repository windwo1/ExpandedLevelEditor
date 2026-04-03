using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUnlockQueryEntityData))]
	public class PVZUnlockQueryEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUnlockQueryEntityData>
	{
		public new FrostySdk.Ebx.PVZUnlockQueryEntityData Data => data as FrostySdk.Ebx.PVZUnlockQueryEntityData;
		public override string DisplayName => "PVZUnlockQuery";

		public PVZUnlockQueryEntity(FrostySdk.Ebx.PVZUnlockQueryEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

