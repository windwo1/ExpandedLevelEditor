using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZLevelControlEntityData))]
	public class PVZLevelControlEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZLevelControlEntityData>
	{
		public new FrostySdk.Ebx.PVZLevelControlEntityData Data => data as FrostySdk.Ebx.PVZLevelControlEntityData;
		public override string DisplayName => "PVZLevelControl";

		public PVZLevelControlEntity(FrostySdk.Ebx.PVZLevelControlEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

