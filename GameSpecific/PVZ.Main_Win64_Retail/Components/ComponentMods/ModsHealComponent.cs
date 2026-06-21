
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsHealComponentData))]
	public class ModsHealComponent : ModsComponent, IEntityData<FrostySdk.Ebx.ModsHealComponentData>
	{
		public new FrostySdk.Ebx.ModsHealComponentData Data => data as FrostySdk.Ebx.ModsHealComponentData;
		public override string DisplayName => "ModsHealComponent";

		public ModsHealComponent(FrostySdk.Ebx.ModsHealComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

