using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SoundAssetSwitcherEntityData))]
	public class SoundAssetSwitcherEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SoundAssetSwitcherEntityData>
	{
		public new FrostySdk.Ebx.SoundAssetSwitcherEntityData Data => data as FrostySdk.Ebx.SoundAssetSwitcherEntityData;
		public override string DisplayName => "SoundAssetSwitcher";

		public SoundAssetSwitcherEntity(FrostySdk.Ebx.SoundAssetSwitcherEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

