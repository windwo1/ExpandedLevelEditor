using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIInputTriggerEntityData))]
	public class UIInputTriggerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIInputTriggerEntityData>
	{
		public new FrostySdk.Ebx.UIInputTriggerEntityData Data => data as FrostySdk.Ebx.UIInputTriggerEntityData;
		public override string DisplayName => "UIInputTrigger";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public UIInputTriggerEntity(FrostySdk.Ebx.UIInputTriggerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

