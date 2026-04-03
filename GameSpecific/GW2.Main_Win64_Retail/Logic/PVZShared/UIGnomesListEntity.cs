using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIGnomesListEntityData))]
	public class UIGnomesListEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIGnomesListEntityData>
	{
		public new FrostySdk.Ebx.UIGnomesListEntityData Data => data as FrostySdk.Ebx.UIGnomesListEntityData;
		public override string DisplayName => "UIGnomesList";

		public UIGnomesListEntity(FrostySdk.Ebx.UIGnomesListEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

