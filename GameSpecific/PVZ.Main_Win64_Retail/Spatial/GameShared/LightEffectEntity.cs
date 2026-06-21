using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.LightEffectEntityData))]
	public class LightEffectEntity : EffectEntity, IEntityData<FrostySdk.Ebx.LightEffectEntityData>
	{
		public new FrostySdk.Ebx.LightEffectEntityData Data => data as FrostySdk.Ebx.LightEffectEntityData;

		public LightEffectEntity(FrostySdk.Ebx.LightEffectEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

