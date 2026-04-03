using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PlayerIdTrackerEntityData))]
	public class PlayerIdTrackerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PlayerIdTrackerEntityData>
	{
		public new FrostySdk.Ebx.PlayerIdTrackerEntityData Data => data as FrostySdk.Ebx.PlayerIdTrackerEntityData;
		public override string DisplayName => "PlayerIdTracker";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PlayerIdTrackerEntity(FrostySdk.Ebx.PlayerIdTrackerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

