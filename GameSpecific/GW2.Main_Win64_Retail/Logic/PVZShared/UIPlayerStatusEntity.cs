using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPlayerStatusEntityData))]
	public class UIPlayerStatusEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIPlayerStatusEntityData>
	{
		public new FrostySdk.Ebx.UIPlayerStatusEntityData Data => data as FrostySdk.Ebx.UIPlayerStatusEntityData;
		public override string DisplayName => "UIPlayerStatus";

		public UIPlayerStatusEntity(FrostySdk.Ebx.UIPlayerStatusEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

