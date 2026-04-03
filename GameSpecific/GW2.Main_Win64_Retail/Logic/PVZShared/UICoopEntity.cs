using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICoopEntityData))]
	public class UICoopEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UICoopEntityData>
	{
		public new FrostySdk.Ebx.UICoopEntityData Data => data as FrostySdk.Ebx.UICoopEntityData;
		public override string DisplayName => "UICoop";

		public UICoopEntity(FrostySdk.Ebx.UICoopEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

