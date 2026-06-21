using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZFloatRangeConverterEntityData))]
	public class PVZFloatRangeConverterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZFloatRangeConverterEntityData>
	{
		public new FrostySdk.Ebx.PVZFloatRangeConverterEntityData Data => data as FrostySdk.Ebx.PVZFloatRangeConverterEntityData;
		public override string DisplayName => "PVZFloatRangeConverter";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZFloatRangeConverterEntity(FrostySdk.Ebx.PVZFloatRangeConverterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

