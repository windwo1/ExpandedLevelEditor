using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCommanderAssetData))]
	public class PVZCommanderAsset : LogicEntity, IEntityData<FrostySdk.Ebx.PVZCommanderAssetData>
	{
		public new FrostySdk.Ebx.PVZCommanderAssetData Data => data as FrostySdk.Ebx.PVZCommanderAssetData;
		public override string DisplayName => "PVZCommanderAsset";

		public PVZCommanderAsset(FrostySdk.Ebx.PVZCommanderAssetData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

