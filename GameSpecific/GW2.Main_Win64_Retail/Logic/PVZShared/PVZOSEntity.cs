using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZOSEntityData))]
	public class PVZOSEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZOSEntityData>
	{
		public new FrostySdk.Ebx.PVZOSEntityData Data => data as FrostySdk.Ebx.PVZOSEntityData;
		public override string DisplayName => "PVZOS";

		public PVZOSEntity(FrostySdk.Ebx.PVZOSEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

