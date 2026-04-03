
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterRollingComponentData))]
	public class PVZCharacterRollingComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZCharacterRollingComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterRollingComponentData Data => data as FrostySdk.Ebx.PVZCharacterRollingComponentData;
		public override string DisplayName => "PVZCharacterRollingComponent";

		public PVZCharacterRollingComponent(FrostySdk.Ebx.PVZCharacterRollingComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

