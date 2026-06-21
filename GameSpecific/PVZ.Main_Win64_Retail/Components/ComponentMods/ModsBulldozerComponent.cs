
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsBulldozerComponentData))]
	public class ModsBulldozerComponent : ModsComponent, IEntityData<FrostySdk.Ebx.ModsBulldozerComponentData>
	{
		public new FrostySdk.Ebx.ModsBulldozerComponentData Data => data as FrostySdk.Ebx.ModsBulldozerComponentData;
		public override string DisplayName => "ModsBulldozerComponent";

		public ModsBulldozerComponent(FrostySdk.Ebx.ModsBulldozerComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

