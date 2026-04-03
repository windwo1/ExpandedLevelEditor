using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.GlobalEffectPlayerEntityData))]
	public class GlobalEffectPlayerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.GlobalEffectPlayerEntityData>
	{
		public new FrostySdk.Ebx.GlobalEffectPlayerEntityData Data => data as FrostySdk.Ebx.GlobalEffectPlayerEntityData;
		public override string DisplayName => "GlobalEffectPlayer";

		public GlobalEffectPlayerEntity(FrostySdk.Ebx.GlobalEffectPlayerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

