using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIObjectiveMessageProviderEntityData))]
	public class UIObjectiveMessageProviderEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIObjectiveMessageProviderEntityData>
	{
		public new FrostySdk.Ebx.UIObjectiveMessageProviderEntityData Data => data as FrostySdk.Ebx.UIObjectiveMessageProviderEntityData;
		public override string DisplayName => "UIObjectiveMessageProvider";

		public UIObjectiveMessageProviderEntity(FrostySdk.Ebx.UIObjectiveMessageProviderEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

