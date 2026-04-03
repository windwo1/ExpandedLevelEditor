using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIUserInfoEntityData))]
	public class UIUserInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIUserInfoEntityData>
	{
		public new FrostySdk.Ebx.UIUserInfoEntityData Data => data as FrostySdk.Ebx.UIUserInfoEntityData;
		public override string DisplayName => "UIUserInfo";

		public UIUserInfoEntity(FrostySdk.Ebx.UIUserInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

