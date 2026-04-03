using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIDisconnectEntityData))]
	public class UIDisconnectEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIDisconnectEntityData>
	{
		public new FrostySdk.Ebx.UIDisconnectEntityData Data => data as FrostySdk.Ebx.UIDisconnectEntityData;
		public override string DisplayName => "UIDisconnect";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public UIDisconnectEntity(FrostySdk.Ebx.UIDisconnectEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

