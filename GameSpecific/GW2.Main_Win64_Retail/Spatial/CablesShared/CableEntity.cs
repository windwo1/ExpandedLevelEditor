using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CableEntityData))]
	public class CableEntity : StaticModelEntity, IEntityData<FrostySdk.Ebx.CableEntityData>
	{
		public new FrostySdk.Ebx.CableEntityData Data => data as FrostySdk.Ebx.CableEntityData;

		public CableEntity(FrostySdk.Ebx.CableEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

