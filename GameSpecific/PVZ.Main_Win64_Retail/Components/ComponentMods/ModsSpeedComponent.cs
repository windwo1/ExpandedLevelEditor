
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsSpeedComponentData))]
	public class ModsSpeedComponent : ModsComponent, IEntityData<FrostySdk.Ebx.ModsSpeedComponentData>
	{
		public new FrostySdk.Ebx.ModsSpeedComponentData Data => data as FrostySdk.Ebx.ModsSpeedComponentData;
		public override string DisplayName => "ModsSpeedComponent";

		public ModsSpeedComponent(FrostySdk.Ebx.ModsSpeedComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

