using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ProceduralAwarenessTargetEntityData))]
	public class ProceduralAwarenessTargetEntity : SpatialEntity, IEntityData<FrostySdk.Ebx.ProceduralAwarenessTargetEntityData>
	{
		public new FrostySdk.Ebx.ProceduralAwarenessTargetEntityData Data => data as FrostySdk.Ebx.ProceduralAwarenessTargetEntityData;
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public ProceduralAwarenessTargetEntity(FrostySdk.Ebx.ProceduralAwarenessTargetEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

