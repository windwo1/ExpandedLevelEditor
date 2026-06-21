
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.HealBeamComponentData))]
	public class HealBeamComponent : GameComponent, IEntityData<FrostySdk.Ebx.HealBeamComponentData>
	{
		public new FrostySdk.Ebx.HealBeamComponentData Data => data as FrostySdk.Ebx.HealBeamComponentData;
		public override string DisplayName => "HealBeamComponent";

		public HealBeamComponent(FrostySdk.Ebx.HealBeamComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

