using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BuffEntityData))]
	public class BuffEntity : LogicEntity, IEntityData<FrostySdk.Ebx.BuffEntityData>
	{
		public new FrostySdk.Ebx.BuffEntityData Data => data as FrostySdk.Ebx.BuffEntityData;
		public override string DisplayName => "Buff";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public BuffEntity(FrostySdk.Ebx.BuffEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

