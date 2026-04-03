
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIObjectTagComponentData))]
	public class UIObjectTagComponent : GameComponent, IEntityData<FrostySdk.Ebx.UIObjectTagComponentData>
	{
		public new FrostySdk.Ebx.UIObjectTagComponentData Data => data as FrostySdk.Ebx.UIObjectTagComponentData;
		public override string DisplayName => "UIObjectTagComponent";

		public UIObjectTagComponent(FrostySdk.Ebx.UIObjectTagComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

