using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIStatsQueryEntityData))]
	public class UIStatsQueryEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIStatsQueryEntityData>
	{
		public new FrostySdk.Ebx.UIStatsQueryEntityData Data => data as FrostySdk.Ebx.UIStatsQueryEntityData;
		public override string DisplayName => "UIStatsQuery";

		public UIStatsQueryEntity(FrostySdk.Ebx.UIStatsQueryEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

