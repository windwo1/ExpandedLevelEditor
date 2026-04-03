using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIObjectTagEntityData))]
	public class UIObjectTagEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.UIObjectTagEntityData>
	{
		public new FrostySdk.Ebx.UIObjectTagEntityData Data => data as FrostySdk.Ebx.UIObjectTagEntityData;

		public UIObjectTagEntity(FrostySdk.Ebx.UIObjectTagEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

