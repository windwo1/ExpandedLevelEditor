
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.InputRestrictionStateComponentData))]
	public class InputRestrictionStateComponent : GameComponent, IEntityData<FrostySdk.Ebx.InputRestrictionStateComponentData>
	{
		public new FrostySdk.Ebx.InputRestrictionStateComponentData Data => data as FrostySdk.Ebx.InputRestrictionStateComponentData;
		public override string DisplayName => "InputRestrictionStateComponent";

		public InputRestrictionStateComponent(FrostySdk.Ebx.InputRestrictionStateComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

