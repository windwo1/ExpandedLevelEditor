using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIGFxDataProviderEntityData))]
	public class UIGFxDataProviderEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIGFxDataProviderEntityData>
	{
		public new FrostySdk.Ebx.UIGFxDataProviderEntityData Data => data as FrostySdk.Ebx.UIGFxDataProviderEntityData;
		public override string DisplayName => "UIGFxDataProvider";

		public UIGFxDataProviderEntity(FrostySdk.Ebx.UIGFxDataProviderEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

