
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterCameraComponentData))]
	public class PVZCharacterCameraComponent : CharacterCameraComponent, IEntityData<FrostySdk.Ebx.PVZCharacterCameraComponentData>
	{
		public new FrostySdk.Ebx.PVZCharacterCameraComponentData Data => data as FrostySdk.Ebx.PVZCharacterCameraComponentData;
		public override string DisplayName => "PVZCharacterCameraComponent";

		public PVZCharacterCameraComponent(FrostySdk.Ebx.PVZCharacterCameraComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

