
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PvZSimpleMeleeComponentData))]
	public class PvZSimpleMeleeComponent : SimpleMeleeComponent, IEntityData<FrostySdk.Ebx.PvZSimpleMeleeComponentData>
	{
		public new FrostySdk.Ebx.PvZSimpleMeleeComponentData Data => data as FrostySdk.Ebx.PvZSimpleMeleeComponentData;
		public override string DisplayName => "PvZSimpleMeleeComponent";

		public PvZSimpleMeleeComponent(FrostySdk.Ebx.PvZSimpleMeleeComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

