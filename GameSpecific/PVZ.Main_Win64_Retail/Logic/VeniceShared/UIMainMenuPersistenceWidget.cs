using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIMainMenuPersistenceWidgetData))]
	public class UIMainMenuPersistenceWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIMainMenuPersistenceWidgetData>
	{
		public new FrostySdk.Ebx.UIMainMenuPersistenceWidgetData Data => data as FrostySdk.Ebx.UIMainMenuPersistenceWidgetData;
		public override string DisplayName => "UIMainMenuPersistenceWidget";

		public UIMainMenuPersistenceWidget(FrostySdk.Ebx.UIMainMenuPersistenceWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

