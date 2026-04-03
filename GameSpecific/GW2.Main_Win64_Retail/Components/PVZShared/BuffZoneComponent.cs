
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BuffZoneComponentData))]
	public class BuffZoneComponent : GameComponent, IEntityData<FrostySdk.Ebx.BuffZoneComponentData>
	{
		public new FrostySdk.Ebx.BuffZoneComponentData Data => data as FrostySdk.Ebx.BuffZoneComponentData;
		public override string DisplayName => "BuffZoneComponent";

		public BuffZoneComponent(FrostySdk.Ebx.BuffZoneComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

