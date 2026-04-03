using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SwitchPropertyFontEffectEntityData))]
	public class SwitchPropertyFontEffectEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SwitchPropertyFontEffectEntityData>
	{
		public new FrostySdk.Ebx.SwitchPropertyFontEffectEntityData Data => data as FrostySdk.Ebx.SwitchPropertyFontEffectEntityData;
		public override string DisplayName => "SwitchPropertyFontEffect";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public SwitchPropertyFontEffectEntity(FrostySdk.Ebx.SwitchPropertyFontEffectEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

