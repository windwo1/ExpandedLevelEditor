using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICalibrateTVScreenWidgetData))]
	public class UICalibrateTVScreenWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UICalibrateTVScreenWidgetData>
	{
		public new FrostySdk.Ebx.UICalibrateTVScreenWidgetData Data => data as FrostySdk.Ebx.UICalibrateTVScreenWidgetData;
		public override string DisplayName => "UICalibrateTVScreenWidget";

		public UICalibrateTVScreenWidget(FrostySdk.Ebx.UICalibrateTVScreenWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

