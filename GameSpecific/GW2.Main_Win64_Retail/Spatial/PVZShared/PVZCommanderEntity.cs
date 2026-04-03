using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCommanderEntityData))]
	public class PVZCommanderEntity : GameComponentEntity, IEntityData<FrostySdk.Ebx.PVZCommanderEntityData>
	{
		public new FrostySdk.Ebx.PVZCommanderEntityData Data => data as FrostySdk.Ebx.PVZCommanderEntityData;

		public PVZCommanderEntity(FrostySdk.Ebx.PVZCommanderEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

