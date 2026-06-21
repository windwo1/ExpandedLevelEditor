
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIPressureComponentData))]
	public class AIPressureComponent : GameComponent, IEntityData<FrostySdk.Ebx.AIPressureComponentData>
	{
		public new FrostySdk.Ebx.AIPressureComponentData Data => data as FrostySdk.Ebx.AIPressureComponentData;
		public override string DisplayName => "AIPressureComponent";

		public AIPressureComponent(FrostySdk.Ebx.AIPressureComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

