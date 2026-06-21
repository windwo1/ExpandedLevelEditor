
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsCloakComponentData))]
	public class ModsCloakComponent : ModsComponent, IEntityData<FrostySdk.Ebx.ModsCloakComponentData>
	{
		public new FrostySdk.Ebx.ModsCloakComponentData Data => data as FrostySdk.Ebx.ModsCloakComponentData;
		public override string DisplayName => "ModsCloakComponent";

		public ModsCloakComponent(FrostySdk.Ebx.ModsCloakComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

