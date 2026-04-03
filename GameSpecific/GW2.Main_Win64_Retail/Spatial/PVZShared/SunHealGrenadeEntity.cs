using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SunHealGrenadeEntityData))]
	public class SunHealGrenadeEntity : GrenadeEntity, IEntityData<FrostySdk.Ebx.SunHealGrenadeEntityData>
	{
		public new FrostySdk.Ebx.SunHealGrenadeEntityData Data => data as FrostySdk.Ebx.SunHealGrenadeEntityData;

		public SunHealGrenadeEntity(FrostySdk.Ebx.SunHealGrenadeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

