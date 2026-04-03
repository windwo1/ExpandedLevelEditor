using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUIMiscSettingsEntityData))]
	public class PVZUIMiscSettingsEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUIMiscSettingsEntityData>
	{
		public new FrostySdk.Ebx.PVZUIMiscSettingsEntityData Data => data as FrostySdk.Ebx.PVZUIMiscSettingsEntityData;
		public override string DisplayName => "PVZUIMiscSettings";

		public PVZUIMiscSettingsEntity(FrostySdk.Ebx.PVZUIMiscSettingsEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

