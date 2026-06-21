using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.RigidBodyData))]
	public class RigidBody : LogicEntity, IEntityData<FrostySdk.Ebx.RigidBodyData>
	{
		public new FrostySdk.Ebx.RigidBodyData Data => data as FrostySdk.Ebx.RigidBodyData;
		public override string DisplayName => "RigidBody";

		public RigidBody(FrostySdk.Ebx.RigidBodyData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

