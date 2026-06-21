
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SetupComponentModsComponentData))]
	public class SetupComponentModsComponent : GameComponent, IEntityData<FrostySdk.Ebx.SetupComponentModsComponentData>
	{
		public new FrostySdk.Ebx.SetupComponentModsComponentData Data => data as FrostySdk.Ebx.SetupComponentModsComponentData;
		public override string DisplayName => "SetupComponentModsComponent";

		public SetupComponentModsComponent(FrostySdk.Ebx.SetupComponentModsComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

