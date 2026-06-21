using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIDirectiveTeleportData))]
	public class AIDirectiveTeleport : AIDirective, IEntityData<FrostySdk.Ebx.AIDirectiveTeleportData>
	{
		public new FrostySdk.Ebx.AIDirectiveTeleportData Data => data as FrostySdk.Ebx.AIDirectiveTeleportData;
		public override string DisplayName => "AIDirectiveTeleport";

		public AIDirectiveTeleport(FrostySdk.Ebx.AIDirectiveTeleportData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

