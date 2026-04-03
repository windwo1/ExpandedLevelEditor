
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZShieldComponent2Data))]
	public class PVZShieldComponent2 : GameComponent, IEntityData<FrostySdk.Ebx.PVZShieldComponent2Data>
	{
		public new FrostySdk.Ebx.PVZShieldComponent2Data Data => data as FrostySdk.Ebx.PVZShieldComponent2Data;
		public override string DisplayName => "PVZShieldComponent2";

		public PVZShieldComponent2(FrostySdk.Ebx.PVZShieldComponent2Data inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

