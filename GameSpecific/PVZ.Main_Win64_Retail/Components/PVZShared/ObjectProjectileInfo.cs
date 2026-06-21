
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ObjectProjectileInfoData))]
	public class ObjectProjectileInfo : GameComponent, IEntityData<FrostySdk.Ebx.ObjectProjectileInfoData>
	{
		public new FrostySdk.Ebx.ObjectProjectileInfoData Data => data as FrostySdk.Ebx.ObjectProjectileInfoData;
		public override string DisplayName => "ObjectProjectileInfo";

		public ObjectProjectileInfo(FrostySdk.Ebx.ObjectProjectileInfoData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

