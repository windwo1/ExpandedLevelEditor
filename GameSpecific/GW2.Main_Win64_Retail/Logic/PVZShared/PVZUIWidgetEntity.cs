using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIWidgetEntityData))]
	public class PVZUIWidgetEntity : UIWidgetEntity, IEntityData<FrostySdk.Ebx.PVZUIWidgetEntityData>
	{
		public new FrostySdk.Ebx.PVZUIWidgetEntityData Data => data as FrostySdk.Ebx.PVZUIWidgetEntityData;
		public override string DisplayName => "PVZUIWidget";

		public PVZUIWidgetEntity(FrostySdk.Ebx.PVZUIWidgetEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

