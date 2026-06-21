
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsComponentData))]
	public class ModsComponent : GameComponent, IEntityData<FrostySdk.Ebx.ModsComponentData>
	{
		public new FrostySdk.Ebx.ModsComponentData Data => data as FrostySdk.Ebx.ModsComponentData;
		public override string DisplayName => "ModsComponent";

		public ModsComponent(FrostySdk.Ebx.ModsComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

