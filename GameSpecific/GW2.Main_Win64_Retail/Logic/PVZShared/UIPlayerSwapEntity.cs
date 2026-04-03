using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPlayerSwapEntityData))]
	public class UIPlayerSwapEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIPlayerSwapEntityData>
	{
		public new FrostySdk.Ebx.UIPlayerSwapEntityData Data => data as FrostySdk.Ebx.UIPlayerSwapEntityData;
		public override string DisplayName => "UIPlayerSwap";

		public UIPlayerSwapEntity(FrostySdk.Ebx.UIPlayerSwapEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

