using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIInteractionInfoEntityData))]
	public class UIInteractionInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIInteractionInfoEntityData>
	{
		public new FrostySdk.Ebx.UIInteractionInfoEntityData Data => data as FrostySdk.Ebx.UIInteractionInfoEntityData;
		public override string DisplayName => "UIInteractionInfo";

		public UIInteractionInfoEntity(FrostySdk.Ebx.UIInteractionInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

