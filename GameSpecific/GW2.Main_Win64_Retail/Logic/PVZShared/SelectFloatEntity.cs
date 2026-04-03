using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SelectFloatEntityData))]
	public class SelectFloatEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SelectFloatEntityData>
	{
		public new FrostySdk.Ebx.SelectFloatEntityData Data => data as FrostySdk.Ebx.SelectFloatEntityData;
		public override string DisplayName => "SelectFloat";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public SelectFloatEntity(FrostySdk.Ebx.SelectFloatEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

