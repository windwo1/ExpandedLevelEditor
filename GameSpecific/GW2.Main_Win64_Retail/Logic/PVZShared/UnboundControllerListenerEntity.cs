using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UnboundControllerListenerEntityData))]
	public class UnboundControllerListenerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UnboundControllerListenerEntityData>
	{
		public new FrostySdk.Ebx.UnboundControllerListenerEntityData Data => data as FrostySdk.Ebx.UnboundControllerListenerEntityData;
		public override string DisplayName => "UnboundControllerListener";

		public UnboundControllerListenerEntity(FrostySdk.Ebx.UnboundControllerListenerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

