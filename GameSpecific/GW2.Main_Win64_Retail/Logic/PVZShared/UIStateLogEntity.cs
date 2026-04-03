using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIStateLogEntityData))]
	public class UIStateLogEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIStateLogEntityData>
	{
		public new FrostySdk.Ebx.UIStateLogEntityData Data => data as FrostySdk.Ebx.UIStateLogEntityData;
		public override string DisplayName => "UIStateLog";

		public UIStateLogEntity(FrostySdk.Ebx.UIStateLogEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

