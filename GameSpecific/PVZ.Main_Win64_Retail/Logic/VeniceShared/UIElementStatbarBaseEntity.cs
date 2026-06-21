using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIElementStatbarBaseEntityData))]
	public class UIElementStatbarBaseEntity : UIElementEntity, IEntityData<FrostySdk.Ebx.UIElementStatbarBaseEntityData>
	{
		public new FrostySdk.Ebx.UIElementStatbarBaseEntityData Data => data as FrostySdk.Ebx.UIElementStatbarBaseEntityData;
		public override string DisplayName => "UIElementStatbarBase";

		public UIElementStatbarBaseEntity(FrostySdk.Ebx.UIElementStatbarBaseEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

