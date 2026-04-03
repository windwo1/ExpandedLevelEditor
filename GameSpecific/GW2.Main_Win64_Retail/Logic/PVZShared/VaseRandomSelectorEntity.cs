using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.VaseRandomSelectorEntityData))]
	public class VaseRandomSelectorEntity : LogicEntity, IEntityData<FrostySdk.Ebx.VaseRandomSelectorEntityData>
	{
		public new FrostySdk.Ebx.VaseRandomSelectorEntityData Data => data as FrostySdk.Ebx.VaseRandomSelectorEntityData;
		public override string DisplayName => "VaseRandomSelector";

		public VaseRandomSelectorEntity(FrostySdk.Ebx.VaseRandomSelectorEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

