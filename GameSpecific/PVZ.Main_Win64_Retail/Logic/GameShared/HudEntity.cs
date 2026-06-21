using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.HudEntityData))]
	public class HudEntity : LogicEntity, IEntityData<FrostySdk.Ebx.HudEntityData>
	{
		public new FrostySdk.Ebx.HudEntityData Data => data as FrostySdk.Ebx.HudEntityData;
		public override string DisplayName => "Hud";

		public HudEntity(FrostySdk.Ebx.HudEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

