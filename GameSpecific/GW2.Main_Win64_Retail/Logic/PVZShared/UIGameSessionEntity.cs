using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIGameSessionEntityData))]
	public class UIGameSessionEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIGameSessionEntityData>
	{
		public new FrostySdk.Ebx.UIGameSessionEntityData Data => data as FrostySdk.Ebx.UIGameSessionEntityData;
		public override string DisplayName => "UIGameSession";

		public UIGameSessionEntity(FrostySdk.Ebx.UIGameSessionEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

