
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsArmorComponentData))]
	public class ModsArmorComponent : ModsComponent, IEntityData<FrostySdk.Ebx.ModsArmorComponentData>
	{
		public new FrostySdk.Ebx.ModsArmorComponentData Data => data as FrostySdk.Ebx.ModsArmorComponentData;
		public override string DisplayName => "ModsArmorComponent";

		public ModsArmorComponent(FrostySdk.Ebx.ModsArmorComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

