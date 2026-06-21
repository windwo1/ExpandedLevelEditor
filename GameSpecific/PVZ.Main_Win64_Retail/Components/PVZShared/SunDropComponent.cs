
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SunDropComponentData))]
	public class SunDropComponent : GameComponent, IEntityData<FrostySdk.Ebx.SunDropComponentData>
	{
		public new FrostySdk.Ebx.SunDropComponentData Data => data as FrostySdk.Ebx.SunDropComponentData;
		public override string DisplayName => "SunDropComponent";

		public SunDropComponent(FrostySdk.Ebx.SunDropComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

