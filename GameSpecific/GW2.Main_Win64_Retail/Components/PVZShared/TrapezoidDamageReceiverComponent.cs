
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TrapezoidDamageReceiverComponentData))]
	public class TrapezoidDamageReceiverComponent : GameComponent, IEntityData<FrostySdk.Ebx.TrapezoidDamageReceiverComponentData>
	{
		public new FrostySdk.Ebx.TrapezoidDamageReceiverComponentData Data => data as FrostySdk.Ebx.TrapezoidDamageReceiverComponentData;
		public override string DisplayName => "TrapezoidDamageReceiverComponent";

		public TrapezoidDamageReceiverComponent(FrostySdk.Ebx.TrapezoidDamageReceiverComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

