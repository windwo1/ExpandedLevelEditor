using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILocalizeTimeEntityData))]
	public class UILocalizeTimeEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UILocalizeTimeEntityData>
	{
		public new FrostySdk.Ebx.UILocalizeTimeEntityData Data => data as FrostySdk.Ebx.UILocalizeTimeEntityData;
		public override string DisplayName => "UILocalizeTime";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public UILocalizeTimeEntity(FrostySdk.Ebx.UILocalizeTimeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

