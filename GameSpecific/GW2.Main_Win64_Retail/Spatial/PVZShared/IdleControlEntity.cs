using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.IdleControlEntityData))]
	public class IdleControlEntity : GameComponentEntity, IEntityData<FrostySdk.Ebx.IdleControlEntityData>
	{
		public new FrostySdk.Ebx.IdleControlEntityData Data => data as FrostySdk.Ebx.IdleControlEntityData;
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public IdleControlEntity(FrostySdk.Ebx.IdleControlEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

