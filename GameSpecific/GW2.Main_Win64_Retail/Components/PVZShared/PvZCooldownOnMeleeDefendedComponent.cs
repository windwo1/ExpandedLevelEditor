
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PvZCooldownOnMeleeDefendedComponentData))]
	public class PvZCooldownOnMeleeDefendedComponent : GameComponent, IEntityData<FrostySdk.Ebx.PvZCooldownOnMeleeDefendedComponentData>
	{
		public new FrostySdk.Ebx.PvZCooldownOnMeleeDefendedComponentData Data => data as FrostySdk.Ebx.PvZCooldownOnMeleeDefendedComponentData;
		public override string DisplayName => "PvZCooldownOnMeleeDefendedComponent";

		public PvZCooldownOnMeleeDefendedComponent(FrostySdk.Ebx.PvZCooldownOnMeleeDefendedComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

