using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UINotificationEntityData))]
	public class UINotificationEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UINotificationEntityData>
	{
		public new FrostySdk.Ebx.UINotificationEntityData Data => data as FrostySdk.Ebx.UINotificationEntityData;
		public override string DisplayName => "UINotification";

		public UINotificationEntity(FrostySdk.Ebx.UINotificationEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

