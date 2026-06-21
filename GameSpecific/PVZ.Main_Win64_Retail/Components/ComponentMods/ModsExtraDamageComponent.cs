
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsExtraDamageComponentData))]
	public class ModsExtraDamageComponent : ModsComponent, IEntityData<FrostySdk.Ebx.ModsExtraDamageComponentData>
	{
		public new FrostySdk.Ebx.ModsExtraDamageComponentData Data => data as FrostySdk.Ebx.ModsExtraDamageComponentData;
		public override string DisplayName => "ModsExtraDamageComponent";

		public ModsExtraDamageComponent(FrostySdk.Ebx.ModsExtraDamageComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

