using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIElementDownloadBitmapEntityData))]
	public class PVZUIElementDownloadBitmapEntity : UIElementBitmapEntity, IEntityData<FrostySdk.Ebx.PVZUIElementDownloadBitmapEntityData>
	{
		public new FrostySdk.Ebx.PVZUIElementDownloadBitmapEntityData Data => data as FrostySdk.Ebx.PVZUIElementDownloadBitmapEntityData;
		public override string DisplayName => "PVZUIElementDownloadBitmap";

		public PVZUIElementDownloadBitmapEntity(FrostySdk.Ebx.PVZUIElementDownloadBitmapEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

