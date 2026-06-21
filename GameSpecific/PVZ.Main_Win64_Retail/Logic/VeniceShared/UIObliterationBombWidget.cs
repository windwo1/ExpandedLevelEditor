using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIObliterationBombWidgetData))]
	public class UIObliterationBombWidget : BFUIWidgetEntity, IEntityData<FrostySdk.Ebx.UIObliterationBombWidgetData>
	{
		public new FrostySdk.Ebx.UIObliterationBombWidgetData Data => data as FrostySdk.Ebx.UIObliterationBombWidgetData;
		public override string DisplayName => "UIObliterationBombWidget";

		public UIObliterationBombWidget(FrostySdk.Ebx.UIObliterationBombWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

