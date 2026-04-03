using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIQuestInfoEntityData))]
	public class UIQuestInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIQuestInfoEntityData>
	{
		public new FrostySdk.Ebx.UIQuestInfoEntityData Data => data as FrostySdk.Ebx.UIQuestInfoEntityData;
		public override string DisplayName => "UIQuestInfo";

		public UIQuestInfoEntity(FrostySdk.Ebx.UIQuestInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

