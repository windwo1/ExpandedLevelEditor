
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ImpartOnProjectileComponentData))]
	public class ImpartOnProjectileComponent : GameComponent, IEntityData<FrostySdk.Ebx.ImpartOnProjectileComponentData>
	{
		public new FrostySdk.Ebx.ImpartOnProjectileComponentData Data => data as FrostySdk.Ebx.ImpartOnProjectileComponentData;
		public override string DisplayName => "ImpartOnProjectileComponent";

		public ImpartOnProjectileComponent(FrostySdk.Ebx.ImpartOnProjectileComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

