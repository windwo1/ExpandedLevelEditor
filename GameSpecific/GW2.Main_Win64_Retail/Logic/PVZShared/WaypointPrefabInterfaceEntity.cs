using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.WaypointPrefabInterfaceEntityData))]
	public class WaypointPrefabInterfaceEntity : LogicEntity, IEntityData<FrostySdk.Ebx.WaypointPrefabInterfaceEntityData>
	{
		public new FrostySdk.Ebx.WaypointPrefabInterfaceEntityData Data => data as FrostySdk.Ebx.WaypointPrefabInterfaceEntityData;
		public override string DisplayName => "WaypointPrefabInterface";

		public WaypointPrefabInterfaceEntity(FrostySdk.Ebx.WaypointPrefabInterfaceEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

