using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZInterpolationEntityData))]
	public class PVZInterpolationEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZInterpolationEntityData>
	{
		public new FrostySdk.Ebx.PVZInterpolationEntityData Data => data as FrostySdk.Ebx.PVZInterpolationEntityData;
		public override string DisplayName => "PVZInterpolation";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZInterpolationEntity(FrostySdk.Ebx.PVZInterpolationEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

