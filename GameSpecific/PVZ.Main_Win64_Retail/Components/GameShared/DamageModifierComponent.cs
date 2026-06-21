
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DamageModifierComponentData))]
	public class DamageModifierComponent : GameComponent, IEntityData<FrostySdk.Ebx.DamageModifierComponentData>
	{
		public new FrostySdk.Ebx.DamageModifierComponentData Data => data as FrostySdk.Ebx.DamageModifierComponentData;
		public override string DisplayName => "DamageModifierComponent";

		public DamageModifierComponent(FrostySdk.Ebx.DamageModifierComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

