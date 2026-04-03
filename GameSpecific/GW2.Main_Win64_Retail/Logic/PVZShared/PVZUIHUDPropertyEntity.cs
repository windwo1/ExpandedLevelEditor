using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIHUDPropertyEntityData))]
	public class PVZUIHUDPropertyEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUIHUDPropertyEntityData>
	{
		public new FrostySdk.Ebx.PVZUIHUDPropertyEntityData Data => data as FrostySdk.Ebx.PVZUIHUDPropertyEntityData;
		public override string DisplayName => "PVZUIHUDProperty";

		public PVZUIHUDPropertyEntity(FrostySdk.Ebx.PVZUIHUDPropertyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

