
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterSoundComponentData))]
	public class PVZCharacterSoundComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZCharacterSoundComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterSoundComponentData Data => data as FrostySdk.Ebx.PVZCharacterSoundComponentData;
		public override string DisplayName => "PVZCharacterSoundComponent";

		public PVZCharacterSoundComponent(FrostySdk.Ebx.PVZCharacterSoundComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

