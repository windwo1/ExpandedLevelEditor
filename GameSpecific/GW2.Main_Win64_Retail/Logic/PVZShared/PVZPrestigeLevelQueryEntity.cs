using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZPrestigeLevelQueryEntityData))]
	public class PVZPrestigeLevelQueryEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZPrestigeLevelQueryEntityData>
	{
		public new FrostySdk.Ebx.PVZPrestigeLevelQueryEntityData Data => data as FrostySdk.Ebx.PVZPrestigeLevelQueryEntityData;
		public override string DisplayName => "PVZPrestigeLevelQuery";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PVZPrestigeLevelQueryEntity(FrostySdk.Ebx.PVZPrestigeLevelQueryEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

