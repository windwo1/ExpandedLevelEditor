using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIConnectionEntityData))]
	public class UIConnectionEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIConnectionEntityData>
	{
		public new FrostySdk.Ebx.UIConnectionEntityData Data => data as FrostySdk.Ebx.UIConnectionEntityData;
		public override string DisplayName => "UIConnection";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public UIConnectionEntity(FrostySdk.Ebx.UIConnectionEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

