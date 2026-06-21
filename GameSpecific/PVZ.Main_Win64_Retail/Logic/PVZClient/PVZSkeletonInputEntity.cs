using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSkeletonInputEntityData))]
	public class PVZSkeletonInputEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZSkeletonInputEntityData>
	{
		public new FrostySdk.Ebx.PVZSkeletonInputEntityData Data => data as FrostySdk.Ebx.PVZSkeletonInputEntityData;
		public override string DisplayName => "PVZSkeletonInput";

		public PVZSkeletonInputEntity(FrostySdk.Ebx.PVZSkeletonInputEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

