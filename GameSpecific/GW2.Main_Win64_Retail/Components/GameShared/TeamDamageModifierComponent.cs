
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TeamDamageModifierComponentData))]
	public class TeamDamageModifierComponent : DamageModifierComponent, IEntityData<FrostySdk.Ebx.TeamDamageModifierComponentData>
	{
		public new FrostySdk.Ebx.TeamDamageModifierComponentData Data => data as FrostySdk.Ebx.TeamDamageModifierComponentData;
		public override string DisplayName => "TeamDamageModifierComponent";

		public TeamDamageModifierComponent(FrostySdk.Ebx.TeamDamageModifierComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

