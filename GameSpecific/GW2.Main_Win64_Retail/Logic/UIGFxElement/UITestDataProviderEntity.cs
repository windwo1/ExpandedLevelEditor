using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UITestDataProviderEntityData))]
	public class UITestDataProviderEntity : UIGFxDataProviderEntity, IEntityData<FrostySdk.Ebx.UITestDataProviderEntityData>
	{
		public new FrostySdk.Ebx.UITestDataProviderEntityData Data => data as FrostySdk.Ebx.UITestDataProviderEntityData;
		public override string DisplayName => "UITestDataProvider";

		public UITestDataProviderEntity(FrostySdk.Ebx.UITestDataProviderEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

