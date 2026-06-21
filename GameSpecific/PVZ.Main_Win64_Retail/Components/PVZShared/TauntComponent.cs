
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TauntComponentData))]
	public class TauntComponent : GameComponent, IEntityData<FrostySdk.Ebx.TauntComponentData>
	{
		public new FrostySdk.Ebx.TauntComponentData Data => data as FrostySdk.Ebx.TauntComponentData;
		public override string DisplayName => "TauntComponent";

		public TauntComponent(FrostySdk.Ebx.TauntComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

