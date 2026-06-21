using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CharacterTriggerFilterEntityData))]
	public class CharacterTriggerFilterEntity : TriggerFilterEntity, IEntityData<FrostySdk.Ebx.CharacterTriggerFilterEntityData>
	{
		public new FrostySdk.Ebx.CharacterTriggerFilterEntityData Data => data as FrostySdk.Ebx.CharacterTriggerFilterEntityData;
		public override string DisplayName => "CharacterTriggerFilter";

		public CharacterTriggerFilterEntity(FrostySdk.Ebx.CharacterTriggerFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

