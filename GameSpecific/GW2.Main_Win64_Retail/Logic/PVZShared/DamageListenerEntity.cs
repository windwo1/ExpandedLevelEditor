using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DamageListenerEntityData))]
	public class DamageListenerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DamageListenerEntityData>
	{
		public new FrostySdk.Ebx.DamageListenerEntityData Data => data as FrostySdk.Ebx.DamageListenerEntityData;
		public override string DisplayName => "DamageListener";

		public DamageListenerEntity(FrostySdk.Ebx.DamageListenerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

