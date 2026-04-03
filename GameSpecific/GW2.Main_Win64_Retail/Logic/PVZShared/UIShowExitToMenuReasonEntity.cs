using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIShowExitToMenuReasonEntityData))]
	public class UIShowExitToMenuReasonEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIShowExitToMenuReasonEntityData>
	{
		public new FrostySdk.Ebx.UIShowExitToMenuReasonEntityData Data => data as FrostySdk.Ebx.UIShowExitToMenuReasonEntityData;
		public override string DisplayName => "UIShowExitToMenuReason";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public UIShowExitToMenuReasonEntity(FrostySdk.Ebx.UIShowExitToMenuReasonEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

