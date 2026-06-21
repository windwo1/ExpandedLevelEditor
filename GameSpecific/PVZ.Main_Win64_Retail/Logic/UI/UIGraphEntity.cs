using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIGraphEntityData))]
	public class UIGraphEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIGraphEntityData>
	{
		public new FrostySdk.Ebx.UIGraphEntityData Data => data as FrostySdk.Ebx.UIGraphEntityData;
		public override string DisplayName => "UIGraph";

		public UIGraphEntity(FrostySdk.Ebx.UIGraphEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

