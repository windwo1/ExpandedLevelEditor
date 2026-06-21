
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AbilityComponentData))]
	public class AbilityComponent : GameComponent, IEntityData<FrostySdk.Ebx.AbilityComponentData>
	{
		public new FrostySdk.Ebx.AbilityComponentData Data => data as FrostySdk.Ebx.AbilityComponentData;
		public override string DisplayName => "AbilityComponent";

		public AbilityComponent(FrostySdk.Ebx.AbilityComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

