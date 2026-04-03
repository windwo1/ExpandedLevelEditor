
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PlayerEntryListenerComponentData))]
	public class PlayerEntryListenerComponent : GameComponent, IEntityData<FrostySdk.Ebx.PlayerEntryListenerComponentData>
	{
		public new FrostySdk.Ebx.PlayerEntryListenerComponentData Data => data as FrostySdk.Ebx.PlayerEntryListenerComponentData;
		public override string DisplayName => "PlayerEntryListenerComponent";

		public PlayerEntryListenerComponent(FrostySdk.Ebx.PlayerEntryListenerComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

