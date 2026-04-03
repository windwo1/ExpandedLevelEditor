using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIElementTextFieldEntityData))]
	public class PVZUIElementTextFieldEntity : UIElementTextFieldEntity, IEntityData<FrostySdk.Ebx.PVZUIElementTextFieldEntityData>
	{
		public new FrostySdk.Ebx.PVZUIElementTextFieldEntityData Data => data as FrostySdk.Ebx.PVZUIElementTextFieldEntityData;
		public override string DisplayName => "PVZUIElementTextField";

		public PVZUIElementTextFieldEntity(FrostySdk.Ebx.PVZUIElementTextFieldEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

