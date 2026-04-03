using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSpawningAnimationSignalEntityData))]
	public class PVZSpawningAnimationSignalEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZSpawningAnimationSignalEntityData>
	{
		public new FrostySdk.Ebx.PVZSpawningAnimationSignalEntityData Data => data as FrostySdk.Ebx.PVZSpawningAnimationSignalEntityData;
		public override string DisplayName => "PVZSpawningAnimationSignal";

		public PVZSpawningAnimationSignalEntity(FrostySdk.Ebx.PVZSpawningAnimationSignalEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

