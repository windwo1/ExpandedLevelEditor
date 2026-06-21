using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BFUIElementButtonBarPressAndReleaseButtonEntityData))]
	public class BFUIElementButtonBarPressAndReleaseButtonEntity : BFUIElementButtonBarButtonEntity, IEntityData<FrostySdk.Ebx.BFUIElementButtonBarPressAndReleaseButtonEntityData>
	{
		public new FrostySdk.Ebx.BFUIElementButtonBarPressAndReleaseButtonEntityData Data => data as FrostySdk.Ebx.BFUIElementButtonBarPressAndReleaseButtonEntityData;
		public override string DisplayName => "BFUIElementButtonBarPressAndReleaseButton";

		public BFUIElementButtonBarPressAndReleaseButtonEntity(FrostySdk.Ebx.BFUIElementButtonBarPressAndReleaseButtonEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

