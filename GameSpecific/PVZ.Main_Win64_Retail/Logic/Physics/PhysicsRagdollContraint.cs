using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PhysicsRagdollContraintData))]
	public class PhysicsRagdollContraint : PhysicsConstraint, IEntityData<FrostySdk.Ebx.PhysicsRagdollContraintData>
	{
		public new FrostySdk.Ebx.PhysicsRagdollContraintData Data => data as FrostySdk.Ebx.PhysicsRagdollContraintData;
		public override string DisplayName => "PhysicsRagdollContraint";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PhysicsRagdollContraint(FrostySdk.Ebx.PhysicsRagdollContraintData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

