using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPreviewBuildMarkerEntityData))]
	public class UIPreviewBuildMarkerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIPreviewBuildMarkerEntityData>
	{
		public new FrostySdk.Ebx.UIPreviewBuildMarkerEntityData Data => data as FrostySdk.Ebx.UIPreviewBuildMarkerEntityData;
		public override string DisplayName => "UIPreviewBuildMarker";

		public UIPreviewBuildMarkerEntity(FrostySdk.Ebx.UIPreviewBuildMarkerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

