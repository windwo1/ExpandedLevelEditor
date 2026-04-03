
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BuffApplicatorComponentData))]
	public class BuffApplicatorComponent : GameComponent, IEntityData<FrostySdk.Ebx.BuffApplicatorComponentData>
	{
		public new FrostySdk.Ebx.BuffApplicatorComponentData Data => data as FrostySdk.Ebx.BuffApplicatorComponentData;
		public override string DisplayName => "BuffApplicatorComponent";

		public BuffApplicatorComponent(FrostySdk.Ebx.BuffApplicatorComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

