using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIActionEntityData))]
	public class UIActionEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIActionEntityData>
	{
		public new FrostySdk.Ebx.UIActionEntityData Data => data as FrostySdk.Ebx.UIActionEntityData;
		public override string DisplayName => "UIAction";

		public UIActionEntity(FrostySdk.Ebx.UIActionEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

