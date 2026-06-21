
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsFogComponentData))]
	public class ModsFogComponent : ModsComponent, IEntityData<FrostySdk.Ebx.ModsFogComponentData>
	{
		public new FrostySdk.Ebx.ModsFogComponentData Data => data as FrostySdk.Ebx.ModsFogComponentData;
		public override string DisplayName => "ModsFogComponent";

		public ModsFogComponent(FrostySdk.Ebx.ModsFogComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

