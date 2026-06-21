using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.VaseEntityData))]
	public class VaseEntity : LogicEntity, IEntityData<FrostySdk.Ebx.VaseEntityData>
	{
		public new FrostySdk.Ebx.VaseEntityData Data => data as FrostySdk.Ebx.VaseEntityData;
		public override string DisplayName => "Vase";

		public VaseEntity(FrostySdk.Ebx.VaseEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

