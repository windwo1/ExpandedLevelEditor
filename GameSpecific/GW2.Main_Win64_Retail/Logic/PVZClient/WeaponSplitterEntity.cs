using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.WeaponSplitterEntityData))]
	public class WeaponSplitterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.WeaponSplitterEntityData>
	{
		public new FrostySdk.Ebx.WeaponSplitterEntityData Data => data as FrostySdk.Ebx.WeaponSplitterEntityData;
		public override string DisplayName => "WeaponSplitter";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public WeaponSplitterEntity(FrostySdk.Ebx.WeaponSplitterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

