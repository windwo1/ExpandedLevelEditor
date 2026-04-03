using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIElementBitmapEntityData))]
	public class PVZUIElementBitmapEntity : UIElementBitmapEntity, IEntityData<FrostySdk.Ebx.PVZUIElementBitmapEntityData>
	{
		public new FrostySdk.Ebx.PVZUIElementBitmapEntityData Data => data as FrostySdk.Ebx.PVZUIElementBitmapEntityData;
		public override string DisplayName => "PVZUIElementBitmap";

		public PVZUIElementBitmapEntity(FrostySdk.Ebx.PVZUIElementBitmapEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

