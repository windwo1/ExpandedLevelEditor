using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIGameGroupEntityData))]
	public class UIGameGroupEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIGameGroupEntityData>
	{
		public new FrostySdk.Ebx.UIGameGroupEntityData Data => data as FrostySdk.Ebx.UIGameGroupEntityData;
		public override string DisplayName => "UIGameGroup";

		public UIGameGroupEntity(FrostySdk.Ebx.UIGameGroupEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

