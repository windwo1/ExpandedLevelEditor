using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICinematicSubtitleEntityData))]
	public class UICinematicSubtitleEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UICinematicSubtitleEntityData>
	{
		public new FrostySdk.Ebx.UICinematicSubtitleEntityData Data => data as FrostySdk.Ebx.UICinematicSubtitleEntityData;
		public override string DisplayName => "UICinematicSubtitle";

		public UICinematicSubtitleEntity(FrostySdk.Ebx.UICinematicSubtitleEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

