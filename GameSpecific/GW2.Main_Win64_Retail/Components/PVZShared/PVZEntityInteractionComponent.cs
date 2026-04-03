
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZEntityInteractionComponentData))]
	public class PVZEntityInteractionComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZEntityInteractionComponentData>
	{
		public new FrostySdk.Ebx.PVZEntityInteractionComponentData Data => data as FrostySdk.Ebx.PVZEntityInteractionComponentData;
		public override string DisplayName => "PVZEntityInteractionComponent";

		public PVZEntityInteractionComponent(FrostySdk.Ebx.PVZEntityInteractionComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

