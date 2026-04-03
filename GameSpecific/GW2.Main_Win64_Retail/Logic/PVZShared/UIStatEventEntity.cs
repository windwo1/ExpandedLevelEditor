using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIStatEventEntityData))]
	public class UIStatEventEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIStatEventEntityData>
	{
		public new FrostySdk.Ebx.UIStatEventEntityData Data => data as FrostySdk.Ebx.UIStatEventEntityData;
		public override string DisplayName => "UIStatEvent";

		public UIStatEventEntity(FrostySdk.Ebx.UIStatEventEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

