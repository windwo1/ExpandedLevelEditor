
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.RadioComponentData))]
	public class RadioComponent : GameComponent, IEntityData<FrostySdk.Ebx.RadioComponentData>
	{
		public new FrostySdk.Ebx.RadioComponentData Data => data as FrostySdk.Ebx.RadioComponentData;
		public override string DisplayName => "RadioComponent";

		public RadioComponent(FrostySdk.Ebx.RadioComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

