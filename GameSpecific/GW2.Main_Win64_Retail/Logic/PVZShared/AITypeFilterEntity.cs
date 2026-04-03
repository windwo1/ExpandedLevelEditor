using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AITypeFilterEntityData))]
	public class AITypeFilterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AITypeFilterEntityData>
	{
		public new FrostySdk.Ebx.AITypeFilterEntityData Data => data as FrostySdk.Ebx.AITypeFilterEntityData;
		public override string DisplayName => "AITypeFilter";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public AITypeFilterEntity(FrostySdk.Ebx.AITypeFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

