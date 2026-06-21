using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIMessageEntityData))]
	public class PVZUIMessageEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUIMessageEntityData>
	{
		public new FrostySdk.Ebx.PVZUIMessageEntityData Data => data as FrostySdk.Ebx.PVZUIMessageEntityData;
		public override string DisplayName => "PVZUIMessage";

		public PVZUIMessageEntity(FrostySdk.Ebx.PVZUIMessageEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

