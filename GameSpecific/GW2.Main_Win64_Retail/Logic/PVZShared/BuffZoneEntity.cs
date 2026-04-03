using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BuffZoneEntityData))]
	public class BuffZoneEntity : LogicEntity, IEntityData<FrostySdk.Ebx.BuffZoneEntityData>
	{
		public new FrostySdk.Ebx.BuffZoneEntityData Data => data as FrostySdk.Ebx.BuffZoneEntityData;
		public override string DisplayName => "BuffZone";

		public BuffZoneEntity(FrostySdk.Ebx.BuffZoneEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

