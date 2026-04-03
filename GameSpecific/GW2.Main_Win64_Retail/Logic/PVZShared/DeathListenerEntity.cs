using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DeathListenerEntityData))]
	public class DeathListenerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DeathListenerEntityData>
	{
		public new FrostySdk.Ebx.DeathListenerEntityData Data => data as FrostySdk.Ebx.DeathListenerEntityData;
		public override string DisplayName => "DeathListener";

		public DeathListenerEntity(FrostySdk.Ebx.DeathListenerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

