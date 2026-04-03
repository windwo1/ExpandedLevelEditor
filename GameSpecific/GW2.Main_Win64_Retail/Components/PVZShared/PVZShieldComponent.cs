
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZShieldComponentData))]
	public class PVZShieldComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZShieldComponentData>
	{
		public new FrostySdk.Ebx.PVZShieldComponentData Data => data as FrostySdk.Ebx.PVZShieldComponentData;
		public override string DisplayName => "PVZShieldComponent";

		public PVZShieldComponent(FrostySdk.Ebx.PVZShieldComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

