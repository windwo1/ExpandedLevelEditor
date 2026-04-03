using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIControllerStateEntityData))]
	public class PVZUIControllerStateEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUIControllerStateEntityData>
	{
		public new FrostySdk.Ebx.PVZUIControllerStateEntityData Data => data as FrostySdk.Ebx.PVZUIControllerStateEntityData;
		public override string DisplayName => "PVZUIControllerState";

		public PVZUIControllerStateEntity(FrostySdk.Ebx.PVZUIControllerStateEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

