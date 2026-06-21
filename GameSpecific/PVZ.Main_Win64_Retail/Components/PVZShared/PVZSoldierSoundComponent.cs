
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZSoldierSoundComponentData))]
	public class PVZSoldierSoundComponent : GameComponent, IEntityData<FrostySdk.Ebx.PVZSoldierSoundComponentData>
	{
		public new FrostySdk.Ebx.PVZSoldierSoundComponentData Data => data as FrostySdk.Ebx.PVZSoldierSoundComponentData;
		public override string DisplayName => "PVZSoldierSoundComponent";

		public PVZSoldierSoundComponent(FrostySdk.Ebx.PVZSoldierSoundComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

