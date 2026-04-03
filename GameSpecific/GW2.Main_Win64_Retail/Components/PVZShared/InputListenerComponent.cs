
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.InputListenerComponentData))]
	public class InputListenerComponent : GameComponent, IEntityData<FrostySdk.Ebx.InputListenerComponentData>
	{
		public new FrostySdk.Ebx.InputListenerComponentData Data => data as FrostySdk.Ebx.InputListenerComponentData;
		public override string DisplayName => "InputListenerComponent";

		public InputListenerComponent(FrostySdk.Ebx.InputListenerComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

