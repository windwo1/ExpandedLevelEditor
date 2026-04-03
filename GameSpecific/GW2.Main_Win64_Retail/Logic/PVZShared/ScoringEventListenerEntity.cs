using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ScoringEventListenerEntityData))]
	public class ScoringEventListenerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ScoringEventListenerEntityData>
	{
		public new FrostySdk.Ebx.ScoringEventListenerEntityData Data => data as FrostySdk.Ebx.ScoringEventListenerEntityData;
		public override string DisplayName => "ScoringEventListener";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public ScoringEventListenerEntity(FrostySdk.Ebx.ScoringEventListenerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

