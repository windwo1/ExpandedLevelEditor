using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZUICustomKeyBindingEntityData))]
	public class PVZUICustomKeyBindingEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZUICustomKeyBindingEntityData>
	{
		public new FrostySdk.Ebx.PVZUICustomKeyBindingEntityData Data => data as FrostySdk.Ebx.PVZUICustomKeyBindingEntityData;
		public override string DisplayName => "PVZUICustomKeyBinding";

		public PVZUICustomKeyBindingEntity(FrostySdk.Ebx.PVZUICustomKeyBindingEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

