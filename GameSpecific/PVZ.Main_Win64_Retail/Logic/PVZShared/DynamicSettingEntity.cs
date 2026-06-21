using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DynamicSettingEntityData))]
	public class DynamicSettingEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DynamicSettingEntityData>
	{
		public new FrostySdk.Ebx.DynamicSettingEntityData Data => data as FrostySdk.Ebx.DynamicSettingEntityData;
		public override string DisplayName => "DynamicSetting";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public DynamicSettingEntity(FrostySdk.Ebx.DynamicSettingEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

