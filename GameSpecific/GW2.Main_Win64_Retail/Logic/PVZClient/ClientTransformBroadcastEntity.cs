using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientTransformBroadcastEntityData))]
	public class ClientTransformBroadcastEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientTransformBroadcastEntityData>
	{
		public new FrostySdk.Ebx.ClientTransformBroadcastEntityData Data => data as FrostySdk.Ebx.ClientTransformBroadcastEntityData;
		public override string DisplayName => "ClientTransformBroadcast";

		public ClientTransformBroadcastEntity(FrostySdk.Ebx.ClientTransformBroadcastEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

