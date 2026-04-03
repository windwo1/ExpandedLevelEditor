using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.StringHubEntityData))]
	public class StringHubEntity : LogicEntity, IEntityData<FrostySdk.Ebx.StringHubEntityData>
	{
		public new FrostySdk.Ebx.StringHubEntityData Data => data as FrostySdk.Ebx.StringHubEntityData;
		public override string DisplayName => "StringHub";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public StringHubEntity(FrostySdk.Ebx.StringHubEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

