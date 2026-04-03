using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPermissionsInfoEntityData))]
	public class PVZPermissionsInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZPermissionsInfoEntityData>
	{
		public new FrostySdk.Ebx.PVZPermissionsInfoEntityData Data => data as FrostySdk.Ebx.PVZPermissionsInfoEntityData;
		public override string DisplayName => "PVZPermissionsInfo";

		public PVZPermissionsInfoEntity(FrostySdk.Ebx.PVZPermissionsInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

