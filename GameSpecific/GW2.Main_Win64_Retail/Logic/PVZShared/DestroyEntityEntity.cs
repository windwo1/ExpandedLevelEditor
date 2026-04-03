using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DestroyEntityEntityData))]
	public class DestroyEntityEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DestroyEntityEntityData>
	{
		public new FrostySdk.Ebx.DestroyEntityEntityData Data => data as FrostySdk.Ebx.DestroyEntityEntityData;
		public override string DisplayName => "DestroyEntity";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public DestroyEntityEntity(FrostySdk.Ebx.DestroyEntityEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

