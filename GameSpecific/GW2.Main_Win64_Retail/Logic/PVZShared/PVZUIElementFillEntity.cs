using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIElementFillEntityData))]
	public class PVZUIElementFillEntity : UIElementFillEntity, IEntityData<FrostySdk.Ebx.PVZUIElementFillEntityData>
	{
		public new FrostySdk.Ebx.PVZUIElementFillEntityData Data => data as FrostySdk.Ebx.PVZUIElementFillEntityData;
		public override string DisplayName => "PVZUIElementFill";

		public PVZUIElementFillEntity(FrostySdk.Ebx.PVZUIElementFillEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

