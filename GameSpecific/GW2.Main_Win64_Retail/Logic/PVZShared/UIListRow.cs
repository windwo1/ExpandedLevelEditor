using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIListRowData))]
	public class UIListRow : PVZUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIListRowData>
	{
		public new FrostySdk.Ebx.UIListRowData Data => data as FrostySdk.Ebx.UIListRowData;
		public override string DisplayName => "UIListRow";

		public UIListRow(FrostySdk.Ebx.UIListRowData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

