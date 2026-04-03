using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZWriteGameStateEntityData))]
	public class PVZWriteGameStateEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZWriteGameStateEntityData>
	{
		public new FrostySdk.Ebx.PVZWriteGameStateEntityData Data => data as FrostySdk.Ebx.PVZWriteGameStateEntityData;
		public override string DisplayName => "PVZWriteGameState";

		public PVZWriteGameStateEntity(FrostySdk.Ebx.PVZWriteGameStateEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

