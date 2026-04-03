using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIGetValueEntityData))]
	public class UIGetValueEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIGetValueEntityData>
	{
		public new FrostySdk.Ebx.UIGetValueEntityData Data => data as FrostySdk.Ebx.UIGetValueEntityData;
		public override string DisplayName => "UIGetValue";

		public UIGetValueEntity(FrostySdk.Ebx.UIGetValueEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

