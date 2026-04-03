using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAttachAnimatablesEntityData))]
	public class PVZAttachAnimatablesEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZAttachAnimatablesEntityData>
	{
		public new FrostySdk.Ebx.PVZAttachAnimatablesEntityData Data => data as FrostySdk.Ebx.PVZAttachAnimatablesEntityData;
		public override string DisplayName => "PVZAttachAnimatables";

		public PVZAttachAnimatablesEntity(FrostySdk.Ebx.PVZAttachAnimatablesEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

