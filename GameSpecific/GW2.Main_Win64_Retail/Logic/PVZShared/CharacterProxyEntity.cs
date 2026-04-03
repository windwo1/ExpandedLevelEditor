using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CharacterProxyEntityData))]
	public class CharacterProxyEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CharacterProxyEntityData>
	{
		public new FrostySdk.Ebx.CharacterProxyEntityData Data => data as FrostySdk.Ebx.CharacterProxyEntityData;
		public override string DisplayName => "CharacterProxy";

		public CharacterProxyEntity(FrostySdk.Ebx.CharacterProxyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

