using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.OnlineGameSessionControlEntityData))]
	public class OnlineGameSessionControlEntity : LogicEntity, IEntityData<FrostySdk.Ebx.OnlineGameSessionControlEntityData>
	{
		public new FrostySdk.Ebx.OnlineGameSessionControlEntityData Data => data as FrostySdk.Ebx.OnlineGameSessionControlEntityData;
		public override string DisplayName => "OnlineGameSessionControl";

		public OnlineGameSessionControlEntity(FrostySdk.Ebx.OnlineGameSessionControlEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

