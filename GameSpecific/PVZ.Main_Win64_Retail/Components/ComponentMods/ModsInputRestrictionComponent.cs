
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsInputRestrictionComponentData))]
	public class ModsInputRestrictionComponent : ModsComponent, IEntityData<FrostySdk.Ebx.ModsInputRestrictionComponentData>
	{
		public new FrostySdk.Ebx.ModsInputRestrictionComponentData Data => data as FrostySdk.Ebx.ModsInputRestrictionComponentData;
		public override string DisplayName => "ModsInputRestrictionComponent";

		public ModsInputRestrictionComponent(FrostySdk.Ebx.ModsInputRestrictionComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

