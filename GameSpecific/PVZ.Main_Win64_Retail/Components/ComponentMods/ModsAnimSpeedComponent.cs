
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsAnimSpeedComponentData))]
	public class ModsAnimSpeedComponent : ModsComponent, IEntityData<FrostySdk.Ebx.ModsAnimSpeedComponentData>
	{
		public new FrostySdk.Ebx.ModsAnimSpeedComponentData Data => data as FrostySdk.Ebx.ModsAnimSpeedComponentData;
		public override string DisplayName => "ModsAnimSpeedComponent";

		public ModsAnimSpeedComponent(FrostySdk.Ebx.ModsAnimSpeedComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

