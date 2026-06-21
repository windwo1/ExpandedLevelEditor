using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIObjectiveWidgetBaseData))]
	public class UIObjectiveWidgetBase : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIObjectiveWidgetBaseData>
	{
		public new FrostySdk.Ebx.UIObjectiveWidgetBaseData Data => data as FrostySdk.Ebx.UIObjectiveWidgetBaseData;
		public override string DisplayName => "UIObjectiveWidgetBase";

		public UIObjectiveWidgetBase(FrostySdk.Ebx.UIObjectiveWidgetBaseData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

