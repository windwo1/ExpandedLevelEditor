
namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ModsStunComponentData))]
	public class ModsStunComponent : ModsInputRestrictionComponent, IEntityData<FrostySdk.Ebx.ModsStunComponentData>
	{
		public new FrostySdk.Ebx.ModsStunComponentData Data => data as FrostySdk.Ebx.ModsStunComponentData;
		public override string DisplayName => "ModsStunComponent";

		public ModsStunComponent(FrostySdk.Ebx.ModsStunComponentData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

