using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DebugCommandEntityData))]
	public class DebugCommandEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DebugCommandEntityData>
	{
		public new FrostySdk.Ebx.DebugCommandEntityData Data => data as FrostySdk.Ebx.DebugCommandEntityData;
		public override string DisplayName => "DebugCommand";

		public DebugCommandEntity(FrostySdk.Ebx.DebugCommandEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

