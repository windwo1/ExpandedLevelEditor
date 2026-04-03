using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UILetterboxEntityData))]
	public class UILetterboxEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UILetterboxEntityData>
	{
		public new FrostySdk.Ebx.UILetterboxEntityData Data => data as FrostySdk.Ebx.UILetterboxEntityData;
		public override string DisplayName => "UILetterbox";

		public UILetterboxEntity(FrostySdk.Ebx.UILetterboxEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

