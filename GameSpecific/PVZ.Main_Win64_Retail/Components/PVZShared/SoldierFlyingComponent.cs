
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SoldierFlyingComponentData))]
	public class SoldierFlyingComponent : GameComponent, IEntityData<FrostySdk.Ebx.SoldierFlyingComponentData>
	{
		public new FrostySdk.Ebx.SoldierFlyingComponentData Data => data as FrostySdk.Ebx.SoldierFlyingComponentData;
		public override string DisplayName => "SoldierFlyingComponent";

		public SoldierFlyingComponent(FrostySdk.Ebx.SoldierFlyingComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

