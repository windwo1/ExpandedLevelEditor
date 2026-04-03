using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PullPhysicsObjectEntityData))]
	public class PullPhysicsObjectEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PullPhysicsObjectEntityData>
	{
		public new FrostySdk.Ebx.PullPhysicsObjectEntityData Data => data as FrostySdk.Ebx.PullPhysicsObjectEntityData;
		public override string DisplayName => "PullPhysicsObject";

		public PullPhysicsObjectEntity(FrostySdk.Ebx.PullPhysicsObjectEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

