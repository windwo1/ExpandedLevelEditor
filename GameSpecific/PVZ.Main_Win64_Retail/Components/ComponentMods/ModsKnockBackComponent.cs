
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsKnockBackComponentData))]
	public class ModsKnockBackComponent : ModsComponent, IEntityData<FrostySdk.Ebx.ModsKnockBackComponentData>
	{
		public new FrostySdk.Ebx.ModsKnockBackComponentData Data => data as FrostySdk.Ebx.ModsKnockBackComponentData;
		public override string DisplayName => "ModsKnockBackComponent";

		public ModsKnockBackComponent(FrostySdk.Ebx.ModsKnockBackComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

