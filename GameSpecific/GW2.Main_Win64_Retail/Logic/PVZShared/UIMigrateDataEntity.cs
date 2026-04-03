using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIMigrateDataEntityData))]
	public class UIMigrateDataEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIMigrateDataEntityData>
	{
		public new FrostySdk.Ebx.UIMigrateDataEntityData Data => data as FrostySdk.Ebx.UIMigrateDataEntityData;
		public override string DisplayName => "UIMigrateData";

		public UIMigrateDataEntity(FrostySdk.Ebx.UIMigrateDataEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

