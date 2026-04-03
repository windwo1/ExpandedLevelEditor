using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UISetValueData))]
	public class UISetValue : LogicEntity, IEntityData<FrostySdk.Ebx.UISetValueData>
	{
		public new FrostySdk.Ebx.UISetValueData Data => data as FrostySdk.Ebx.UISetValueData;
		public override string DisplayName => "UISetValue";

		public UISetValue(FrostySdk.Ebx.UISetValueData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

