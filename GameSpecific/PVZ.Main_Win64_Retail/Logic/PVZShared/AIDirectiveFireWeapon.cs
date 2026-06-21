using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIDirectiveFireWeaponData))]
	public class AIDirectiveFireWeapon : AIDirective, IEntityData<FrostySdk.Ebx.AIDirectiveFireWeaponData>
	{
		public new FrostySdk.Ebx.AIDirectiveFireWeaponData Data => data as FrostySdk.Ebx.AIDirectiveFireWeaponData;
		public override string DisplayName => "AIDirectiveFireWeapon";

		public AIDirectiveFireWeapon(FrostySdk.Ebx.AIDirectiveFireWeaponData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

