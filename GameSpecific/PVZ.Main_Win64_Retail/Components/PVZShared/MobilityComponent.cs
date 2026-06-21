
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.MobilityComponentData))]
	public class MobilityComponent : GameComponent, IEntityData<FrostySdk.Ebx.MobilityComponentData>
	{
		public new FrostySdk.Ebx.MobilityComponentData Data => data as FrostySdk.Ebx.MobilityComponentData;
		public override string DisplayName => "MobilityComponent";

		public MobilityComponent(FrostySdk.Ebx.MobilityComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

