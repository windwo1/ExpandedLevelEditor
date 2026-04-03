using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.WeaponProxyEntityData))]
	public class WeaponProxyEntity : LogicEntity, IEntityData<FrostySdk.Ebx.WeaponProxyEntityData>
	{
		public new FrostySdk.Ebx.WeaponProxyEntityData Data => data as FrostySdk.Ebx.WeaponProxyEntityData;
		public override string DisplayName => "WeaponProxy";

		public WeaponProxyEntity(FrostySdk.Ebx.WeaponProxyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

