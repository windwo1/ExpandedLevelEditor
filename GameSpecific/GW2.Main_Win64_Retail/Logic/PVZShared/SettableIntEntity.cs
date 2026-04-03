using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SettableIntEntityData))]
	public class SettableIntEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SettableIntEntityData>
	{
		public new FrostySdk.Ebx.SettableIntEntityData Data => data as FrostySdk.Ebx.SettableIntEntityData;
		public override string DisplayName => "SettableInt";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public SettableIntEntity(FrostySdk.Ebx.SettableIntEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

