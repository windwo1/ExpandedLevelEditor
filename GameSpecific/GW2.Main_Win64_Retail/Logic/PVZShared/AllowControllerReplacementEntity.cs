using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AllowControllerReplacementEntityData))]
	public class AllowControllerReplacementEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AllowControllerReplacementEntityData>
	{
		public new FrostySdk.Ebx.AllowControllerReplacementEntityData Data => data as FrostySdk.Ebx.AllowControllerReplacementEntityData;
		public override string DisplayName => "AllowControllerReplacement";

		public AllowControllerReplacementEntity(FrostySdk.Ebx.AllowControllerReplacementEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

