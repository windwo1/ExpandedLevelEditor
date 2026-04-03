
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterScalingComponentData))]
	public class PVZCharacterScalingComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZCharacterScalingComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterScalingComponentData Data => data as FrostySdk.Ebx.PVZCharacterScalingComponentData;
		public override string DisplayName => "PVZCharacterScalingComponent";

		public PVZCharacterScalingComponent(FrostySdk.Ebx.PVZCharacterScalingComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

