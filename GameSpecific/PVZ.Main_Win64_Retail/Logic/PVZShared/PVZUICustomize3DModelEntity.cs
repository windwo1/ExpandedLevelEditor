using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUICustomize3DModelEntityData))]
	public class PVZUICustomize3DModelEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUICustomize3DModelEntityData>
	{
		public new FrostySdk.Ebx.PVZUICustomize3DModelEntityData Data => data as FrostySdk.Ebx.PVZUICustomize3DModelEntityData;
		public override string DisplayName => "PVZUICustomize3DModel";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZUICustomize3DModelEntity(FrostySdk.Ebx.PVZUICustomize3DModelEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

