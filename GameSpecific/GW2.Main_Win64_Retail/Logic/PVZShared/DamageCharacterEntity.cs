using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DamageCharacterEntityData))]
	public class DamageCharacterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DamageCharacterEntityData>
	{
		public new FrostySdk.Ebx.DamageCharacterEntityData Data => data as FrostySdk.Ebx.DamageCharacterEntityData;
		public override string DisplayName => "DamageCharacter";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public DamageCharacterEntity(FrostySdk.Ebx.DamageCharacterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

