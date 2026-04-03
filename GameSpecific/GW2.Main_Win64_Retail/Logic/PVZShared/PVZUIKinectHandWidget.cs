using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIKinectHandWidgetData))]
	public class PVZUIKinectHandWidget : UILegacyWidgetEntity, IEntityData<FrostySdk.Ebx.PVZUIKinectHandWidgetData>
	{
		public new FrostySdk.Ebx.PVZUIKinectHandWidgetData Data => data as FrostySdk.Ebx.PVZUIKinectHandWidgetData;
		public override string DisplayName => "PVZUIKinectHandWidget";

		public PVZUIKinectHandWidget(FrostySdk.Ebx.PVZUIKinectHandWidgetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

