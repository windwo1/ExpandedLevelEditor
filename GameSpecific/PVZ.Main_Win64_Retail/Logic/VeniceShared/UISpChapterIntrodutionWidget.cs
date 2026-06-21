using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISpChapterIntrodutionWidgetData))]
	public class UISpChapterIntrodutionWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UISpChapterIntrodutionWidgetData>
	{
		public new FrostySdk.Ebx.UISpChapterIntrodutionWidgetData Data => data as FrostySdk.Ebx.UISpChapterIntrodutionWidgetData;
		public override string DisplayName => "UISpChapterIntrodutionWidget";

		public UISpChapterIntrodutionWidget(FrostySdk.Ebx.UISpChapterIntrodutionWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

