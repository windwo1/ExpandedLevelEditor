using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIMatchmakingEntityData))]
	public class UIMatchmakingEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIMatchmakingEntityData>
	{
		public new FrostySdk.Ebx.UIMatchmakingEntityData Data => data as FrostySdk.Ebx.UIMatchmakingEntityData;
		public override string DisplayName => "UIMatchmaking";

		public UIMatchmakingEntity(FrostySdk.Ebx.UIMatchmakingEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

