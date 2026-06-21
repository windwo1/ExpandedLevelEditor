using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CharacterAnimationSpaceEntityData))]
	public class CharacterAnimationSpaceEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CharacterAnimationSpaceEntityData>
	{
		public new FrostySdk.Ebx.CharacterAnimationSpaceEntityData Data => data as FrostySdk.Ebx.CharacterAnimationSpaceEntityData;
		public override string DisplayName => "CharacterAnimationSpace";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public CharacterAnimationSpaceEntity(FrostySdk.Ebx.CharacterAnimationSpaceEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

