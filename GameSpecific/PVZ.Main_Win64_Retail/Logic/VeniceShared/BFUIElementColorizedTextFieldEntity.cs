using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BFUIElementColorizedTextFieldEntityData))]
	public class BFUIElementColorizedTextFieldEntity : UIElementTextFieldEntity, IEntityData<FrostySdk.Ebx.BFUIElementColorizedTextFieldEntityData>
	{
		public new FrostySdk.Ebx.BFUIElementColorizedTextFieldEntityData Data => data as FrostySdk.Ebx.BFUIElementColorizedTextFieldEntityData;
		public override string DisplayName => "BFUIElementColorizedTextField";

		public BFUIElementColorizedTextFieldEntity(FrostySdk.Ebx.BFUIElementColorizedTextFieldEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

