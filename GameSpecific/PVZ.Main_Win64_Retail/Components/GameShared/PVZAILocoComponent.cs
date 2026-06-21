
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZAILocoComponentData))]
	public class PVZAILocoComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZAILocoComponentData>
	{
		public new FrostySdk.Ebx.PVZAILocoComponentData Data => data as FrostySdk.Ebx.PVZAILocoComponentData;
		public override string DisplayName => "PVZAILocoComponent";

		public PVZAILocoComponent(FrostySdk.Ebx.PVZAILocoComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

