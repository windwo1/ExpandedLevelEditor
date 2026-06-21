using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZFireWeaponActionData))]
	public class PVZFireWeaponAction : PVZCommanderActionBase, IEntityData<FrostySdk.Ebx.PVZFireWeaponActionData>
	{
		public new FrostySdk.Ebx.PVZFireWeaponActionData Data => data as FrostySdk.Ebx.PVZFireWeaponActionData;
		public override string DisplayName => "PVZFireWeaponAction";

		public PVZFireWeaponAction(FrostySdk.Ebx.PVZFireWeaponActionData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

