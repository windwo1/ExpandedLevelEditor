
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.WaterComponentData))]
	public class WaterComponent : GameComponent, IEntityData<FrostySdk.Ebx.WaterComponentData>
	{
		public new FrostySdk.Ebx.WaterComponentData Data => data as FrostySdk.Ebx.WaterComponentData;
		public override string DisplayName => "WaterComponent";

		public WaterComponent(FrostySdk.Ebx.WaterComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

