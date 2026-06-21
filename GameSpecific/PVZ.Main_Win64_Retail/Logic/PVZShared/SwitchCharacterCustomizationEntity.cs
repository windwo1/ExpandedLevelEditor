using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SwitchCharacterCustomizationEntityData))]
	public class SwitchCharacterCustomizationEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SwitchCharacterCustomizationEntityData>
	{
		public new FrostySdk.Ebx.SwitchCharacterCustomizationEntityData Data => data as FrostySdk.Ebx.SwitchCharacterCustomizationEntityData;
		public override string DisplayName => "SwitchCharacterCustomization";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public SwitchCharacterCustomizationEntity(FrostySdk.Ebx.SwitchCharacterCustomizationEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

