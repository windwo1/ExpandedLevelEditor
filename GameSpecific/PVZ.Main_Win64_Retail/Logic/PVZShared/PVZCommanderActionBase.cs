using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCommanderActionBaseData))]
	public class PVZCommanderActionBase : LogicEntity, IEntityData<FrostySdk.Ebx.PVZCommanderActionBaseData>
	{
		public new FrostySdk.Ebx.PVZCommanderActionBaseData Data => data as FrostySdk.Ebx.PVZCommanderActionBaseData;
		public override string DisplayName => "PVZCommanderActionBase";

		public PVZCommanderActionBase(FrostySdk.Ebx.PVZCommanderActionBaseData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

