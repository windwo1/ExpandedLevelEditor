using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSaveSetValueEntityData))]
	public class PVZSaveSetValueEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZSaveSetValueEntityData>
	{
		public new FrostySdk.Ebx.PVZSaveSetValueEntityData Data => data as FrostySdk.Ebx.PVZSaveSetValueEntityData;
		public override string DisplayName => "PVZSaveSetValue";

		public PVZSaveSetValueEntity(FrostySdk.Ebx.PVZSaveSetValueEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

