using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientGnomeTargetsEntityData))]
	public class ClientGnomeTargetsEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientGnomeTargetsEntityData>
	{
		public new FrostySdk.Ebx.ClientGnomeTargetsEntityData Data => data as FrostySdk.Ebx.ClientGnomeTargetsEntityData;
		public override string DisplayName => "ClientGnomeTargets";

		public ClientGnomeTargetsEntity(FrostySdk.Ebx.ClientGnomeTargetsEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

