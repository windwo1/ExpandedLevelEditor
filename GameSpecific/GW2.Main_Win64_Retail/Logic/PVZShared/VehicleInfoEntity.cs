using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.VehicleInfoEntityData))]
	public class VehicleInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.VehicleInfoEntityData>
	{
		public new FrostySdk.Ebx.VehicleInfoEntityData Data => data as FrostySdk.Ebx.VehicleInfoEntityData;
		public override string DisplayName => "VehicleInfo";

		public VehicleInfoEntity(FrostySdk.Ebx.VehicleInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

