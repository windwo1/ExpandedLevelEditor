using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SoldierFallbackEntityData))]
	public class SoldierFallbackEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SoldierFallbackEntityData>
	{
		public new FrostySdk.Ebx.SoldierFallbackEntityData Data => data as FrostySdk.Ebx.SoldierFallbackEntityData;
		public override string DisplayName => "SoldierFallback";

		public SoldierFallbackEntity(FrostySdk.Ebx.SoldierFallbackEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

