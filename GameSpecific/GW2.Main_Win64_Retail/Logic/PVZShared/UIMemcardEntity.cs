using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIMemcardEntityData))]
	public class UIMemcardEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIMemcardEntityData>
	{
		public new FrostySdk.Ebx.UIMemcardEntityData Data => data as FrostySdk.Ebx.UIMemcardEntityData;
		public override string DisplayName => "UIMemcard";

		public UIMemcardEntity(FrostySdk.Ebx.UIMemcardEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

