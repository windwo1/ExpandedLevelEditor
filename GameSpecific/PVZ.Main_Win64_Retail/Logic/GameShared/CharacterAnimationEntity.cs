using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CharacterAnimationEntityData))]
	public class CharacterAnimationEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CharacterAnimationEntityData>
	{
		public new FrostySdk.Ebx.CharacterAnimationEntityData Data => data as FrostySdk.Ebx.CharacterAnimationEntityData;
		public override string DisplayName => "CharacterAnimation";

		public CharacterAnimationEntity(FrostySdk.Ebx.CharacterAnimationEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

