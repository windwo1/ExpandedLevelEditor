using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIElementStatbarEntityData))]
	public class UIElementStatbarEntity : UIElementStatbarBaseEntity, IEntityData<FrostySdk.Ebx.UIElementStatbarEntityData>
	{
		public new FrostySdk.Ebx.UIElementStatbarEntityData Data => data as FrostySdk.Ebx.UIElementStatbarEntityData;
		public override string DisplayName => "UIElementStatbar";

		public UIElementStatbarEntity(FrostySdk.Ebx.UIElementStatbarEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

