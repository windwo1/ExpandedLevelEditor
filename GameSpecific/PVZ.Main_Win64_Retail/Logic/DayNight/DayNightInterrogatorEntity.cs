using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DayNightInterrogatorEntityData))]
	public class DayNightInterrogatorEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DayNightInterrogatorEntityData>
	{
		public new FrostySdk.Ebx.DayNightInterrogatorEntityData Data => data as FrostySdk.Ebx.DayNightInterrogatorEntityData;
		public override string DisplayName => "DayNightInterrogator";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public DayNightInterrogatorEntity(FrostySdk.Ebx.DayNightInterrogatorEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

