using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITurretRotationWidgetData))]
	public class UITurretRotationWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UITurretRotationWidgetData>
	{
		public new FrostySdk.Ebx.UITurretRotationWidgetData Data => data as FrostySdk.Ebx.UITurretRotationWidgetData;
		public override string DisplayName => "UITurretRotationWidget";

		public UITurretRotationWidget(FrostySdk.Ebx.UITurretRotationWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

