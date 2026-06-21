using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DoublePlayerEventSplitterEntityData))]
	public class DoublePlayerEventSplitterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DoublePlayerEventSplitterEntityData>
	{
		public new FrostySdk.Ebx.DoublePlayerEventSplitterEntityData Data => data as FrostySdk.Ebx.DoublePlayerEventSplitterEntityData;
		public override string DisplayName => "DoublePlayerEventSplitter";

		public DoublePlayerEventSplitterEntity(FrostySdk.Ebx.DoublePlayerEventSplitterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

