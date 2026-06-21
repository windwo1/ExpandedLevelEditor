
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TrapezoidDamageComponentData))]
	public class TrapezoidDamageComponent : GameComponent, IEntityData<FrostySdk.Ebx.TrapezoidDamageComponentData>
	{
		public new FrostySdk.Ebx.TrapezoidDamageComponentData Data => data as FrostySdk.Ebx.TrapezoidDamageComponentData;
		public override string DisplayName => "TrapezoidDamageComponent";

		public TrapezoidDamageComponent(FrostySdk.Ebx.TrapezoidDamageComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

