using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.GlobalEventEntityData))]
	public class GlobalEventEntity : LogicEntity, IEntityData<FrostySdk.Ebx.GlobalEventEntityData>
	{
		public new FrostySdk.Ebx.GlobalEventEntityData Data => data as FrostySdk.Ebx.GlobalEventEntityData;
		public override string DisplayName => "GlobalEvent";

		public GlobalEventEntity(FrostySdk.Ebx.GlobalEventEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

