using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSaveBytevaultEntityData))]
	public class PVZSaveBytevaultEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZSaveBytevaultEntityData>
	{
		public new FrostySdk.Ebx.PVZSaveBytevaultEntityData Data => data as FrostySdk.Ebx.PVZSaveBytevaultEntityData;
		public override string DisplayName => "PVZSaveBytevault";

		public PVZSaveBytevaultEntity(FrostySdk.Ebx.PVZSaveBytevaultEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

