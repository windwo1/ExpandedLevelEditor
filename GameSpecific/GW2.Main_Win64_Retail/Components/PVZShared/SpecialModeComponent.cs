
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SpecialModeComponentData))]
	public class SpecialModeComponent : GameComponent, IEntityData<FrostySdk.Ebx.SpecialModeComponentData>
	{
		public new FrostySdk.Ebx.SpecialModeComponentData Data => data as FrostySdk.Ebx.SpecialModeComponentData;
		public override string DisplayName => "SpecialModeComponent";

		public SpecialModeComponent(FrostySdk.Ebx.SpecialModeComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

