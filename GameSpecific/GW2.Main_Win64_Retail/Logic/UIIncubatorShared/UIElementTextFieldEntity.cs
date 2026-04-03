using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIElementTextFieldEntityData))]
	public class UIElementTextFieldEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIElementTextFieldEntityData>
	{
		public new FrostySdk.Ebx.UIElementTextFieldEntityData Data => data as FrostySdk.Ebx.UIElementTextFieldEntityData;
		public override string DisplayName => "UIElementTextField";

		public UIElementTextFieldEntity(FrostySdk.Ebx.UIElementTextFieldEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

