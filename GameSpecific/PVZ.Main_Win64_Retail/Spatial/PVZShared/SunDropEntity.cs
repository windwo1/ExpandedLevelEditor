using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SunDropEntityData))]
	public class SunDropEntity : PVZGrenadeEntity, IEntityData<FrostySdk.Ebx.SunDropEntityData>
	{
		public new FrostySdk.Ebx.SunDropEntityData Data => data as FrostySdk.Ebx.SunDropEntityData;

		public SunDropEntity(FrostySdk.Ebx.SunDropEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

