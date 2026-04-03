using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPopupEntityData))]
	public class UIPopupEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIPopupEntityData>
	{
		public new FrostySdk.Ebx.UIPopupEntityData Data => data as FrostySdk.Ebx.UIPopupEntityData;
		public override string DisplayName => "UIPopup";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public UIPopupEntity(FrostySdk.Ebx.UIPopupEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

