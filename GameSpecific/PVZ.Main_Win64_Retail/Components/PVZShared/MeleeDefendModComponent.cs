
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.MeleeDefendModComponentData))]
	public class MeleeDefendModComponent : ModsComponent, IEntityData<FrostySdk.Ebx.MeleeDefendModComponentData>
	{
		public new FrostySdk.Ebx.MeleeDefendModComponentData Data => data as FrostySdk.Ebx.MeleeDefendModComponentData;
		public override string DisplayName => "MeleeDefendModComponent";

		public MeleeDefendModComponent(FrostySdk.Ebx.MeleeDefendModComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

