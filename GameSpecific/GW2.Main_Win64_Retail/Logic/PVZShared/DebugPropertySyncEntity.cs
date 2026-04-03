using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DebugPropertySyncEntityData))]
	public class DebugPropertySyncEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DebugPropertySyncEntityData>
	{
		public new FrostySdk.Ebx.DebugPropertySyncEntityData Data => data as FrostySdk.Ebx.DebugPropertySyncEntityData;
		public override string DisplayName => "DebugPropertySync";

		public DebugPropertySyncEntity(FrostySdk.Ebx.DebugPropertySyncEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

