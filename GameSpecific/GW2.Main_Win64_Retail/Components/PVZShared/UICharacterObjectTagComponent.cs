
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICharacterObjectTagComponentData))]
	public class UICharacterObjectTagComponent : UIObjectTagComponent, IEntityData<FrostySdk.Ebx.UICharacterObjectTagComponentData>
	{
		public new FrostySdk.Ebx.UICharacterObjectTagComponentData Data => data as FrostySdk.Ebx.UICharacterObjectTagComponentData;
		public override string DisplayName => "UICharacterObjectTagComponent";

		public UICharacterObjectTagComponent(FrostySdk.Ebx.UICharacterObjectTagComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

