
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BuffRadiatorComponentData))]
	public class BuffRadiatorComponent : GameComponent, IEntityData<FrostySdk.Ebx.BuffRadiatorComponentData>
	{
		public new FrostySdk.Ebx.BuffRadiatorComponentData Data => data as FrostySdk.Ebx.BuffRadiatorComponentData;
		public override string DisplayName => "BuffRadiatorComponent";

		public BuffRadiatorComponent(FrostySdk.Ebx.BuffRadiatorComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

