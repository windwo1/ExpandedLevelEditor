using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SelectIntEntityData))]
	public class SelectIntEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SelectIntEntityData>
	{
		public new FrostySdk.Ebx.SelectIntEntityData Data => data as FrostySdk.Ebx.SelectIntEntityData;
		public override string DisplayName => "SelectInt";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public SelectIntEntity(FrostySdk.Ebx.SelectIntEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

