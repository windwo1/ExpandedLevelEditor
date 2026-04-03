using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZStatQueryEntityData))]
	public class PVZStatQueryEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZStatQueryEntityData>
	{
		public new FrostySdk.Ebx.PVZStatQueryEntityData Data => data as FrostySdk.Ebx.PVZStatQueryEntityData;
		public override string DisplayName => "PVZStatQuery";

		public PVZStatQueryEntity(FrostySdk.Ebx.PVZStatQueryEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

