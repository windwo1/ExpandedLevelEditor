
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BurningComponentData))]
	public class BurningComponent : Component, IEntityData<FrostySdk.Ebx.BurningComponentData>
	{
		public new FrostySdk.Ebx.BurningComponentData Data => data as FrostySdk.Ebx.BurningComponentData;
		public override string DisplayName => "BurningComponent";

		public BurningComponent(FrostySdk.Ebx.BurningComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

