using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIGameSessionPlayerEntityData))]
	public class UIGameSessionPlayerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIGameSessionPlayerEntityData>
	{
		public new FrostySdk.Ebx.UIGameSessionPlayerEntityData Data => data as FrostySdk.Ebx.UIGameSessionPlayerEntityData;
		public override string DisplayName => "UIGameSessionPlayer";

		public UIGameSessionPlayerEntity(FrostySdk.Ebx.UIGameSessionPlayerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

