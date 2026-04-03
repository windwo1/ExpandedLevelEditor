using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIGetLegalDocEntityData))]
	public class PVZUIGetLegalDocEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUIGetLegalDocEntityData>
	{
		public new FrostySdk.Ebx.PVZUIGetLegalDocEntityData Data => data as FrostySdk.Ebx.PVZUIGetLegalDocEntityData;
		public override string DisplayName => "PVZUIGetLegalDoc";

		public PVZUIGetLegalDocEntity(FrostySdk.Ebx.PVZUIGetLegalDocEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

