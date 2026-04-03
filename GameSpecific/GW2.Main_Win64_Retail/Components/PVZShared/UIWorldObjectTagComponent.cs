
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIWorldObjectTagComponentData))]
	public class UIWorldObjectTagComponent : UIObjectTagComponent, IEntityData<FrostySdk.Ebx.UIWorldObjectTagComponentData>
	{
		public new FrostySdk.Ebx.UIWorldObjectTagComponentData Data => data as FrostySdk.Ebx.UIWorldObjectTagComponentData;
		public override string DisplayName => "UIWorldObjectTagComponent";

		public UIWorldObjectTagComponent(FrostySdk.Ebx.UIWorldObjectTagComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

