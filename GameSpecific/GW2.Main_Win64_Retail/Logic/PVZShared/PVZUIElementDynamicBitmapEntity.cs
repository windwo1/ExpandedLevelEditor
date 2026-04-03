using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIElementDynamicBitmapEntityData))]
	public class PVZUIElementDynamicBitmapEntity : UIElementBitmapEntity, IEntityData<FrostySdk.Ebx.PVZUIElementDynamicBitmapEntityData>
	{
		public new FrostySdk.Ebx.PVZUIElementDynamicBitmapEntityData Data => data as FrostySdk.Ebx.PVZUIElementDynamicBitmapEntityData;
		public override string DisplayName => "PVZUIElementDynamicBitmap";

		public PVZUIElementDynamicBitmapEntity(FrostySdk.Ebx.PVZUIElementDynamicBitmapEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

