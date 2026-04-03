using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAssetReferenceData))]
	public class PVZAssetReference : LogicEntity, IEntityData<FrostySdk.Ebx.PVZAssetReferenceData>
	{
		public new FrostySdk.Ebx.PVZAssetReferenceData Data => data as FrostySdk.Ebx.PVZAssetReferenceData;
		public override string DisplayName => "PVZAssetReference";

		public PVZAssetReference(FrostySdk.Ebx.PVZAssetReferenceData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

