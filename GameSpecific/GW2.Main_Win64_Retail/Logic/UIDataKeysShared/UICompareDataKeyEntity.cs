using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICompareDataKeyEntityData))]
	public class UICompareDataKeyEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UICompareDataKeyEntityData>
	{
		public new FrostySdk.Ebx.UICompareDataKeyEntityData Data => data as FrostySdk.Ebx.UICompareDataKeyEntityData;
		public override string DisplayName => "UICompareDataKey";

		public UICompareDataKeyEntity(FrostySdk.Ebx.UICompareDataKeyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

