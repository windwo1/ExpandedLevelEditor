using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIPendingInviteEntityData))]
	public class UIPendingInviteEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIPendingInviteEntityData>
	{
		public new FrostySdk.Ebx.UIPendingInviteEntityData Data => data as FrostySdk.Ebx.UIPendingInviteEntityData;
		public override string DisplayName => "UIPendingInvite";

		public UIPendingInviteEntity(FrostySdk.Ebx.UIPendingInviteEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

