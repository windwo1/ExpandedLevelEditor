using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CompareLocalPlayerIdEntityData))]
	public class CompareLocalPlayerIdEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CompareLocalPlayerIdEntityData>
	{
		public new FrostySdk.Ebx.CompareLocalPlayerIdEntityData Data => data as FrostySdk.Ebx.CompareLocalPlayerIdEntityData;
		public override string DisplayName => "CompareLocalPlayerId";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public CompareLocalPlayerIdEntity(FrostySdk.Ebx.CompareLocalPlayerIdEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

