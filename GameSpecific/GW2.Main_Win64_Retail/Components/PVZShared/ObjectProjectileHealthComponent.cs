
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ObjectProjectileHealthComponentData))]
	public class ObjectProjectileHealthComponent : GameHealthComponent, IEntityData<FrostySdk.Ebx.ObjectProjectileHealthComponentData>
	{
		public new FrostySdk.Ebx.ObjectProjectileHealthComponentData Data => data as FrostySdk.Ebx.ObjectProjectileHealthComponentData;
		public override string DisplayName => "ObjectProjectileHealthComponent";

		public ObjectProjectileHealthComponent(FrostySdk.Ebx.ObjectProjectileHealthComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

