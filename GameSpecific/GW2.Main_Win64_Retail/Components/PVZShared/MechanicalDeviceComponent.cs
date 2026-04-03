
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.MechanicalDeviceComponentData))]
	public class MechanicalDeviceComponent : GameComponent, IEntityData<FrostySdk.Ebx.MechanicalDeviceComponentData>
	{
		public new FrostySdk.Ebx.MechanicalDeviceComponentData Data => data as FrostySdk.Ebx.MechanicalDeviceComponentData;
		public override string DisplayName => "MechanicalDeviceComponent";

		public MechanicalDeviceComponent(FrostySdk.Ebx.MechanicalDeviceComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

