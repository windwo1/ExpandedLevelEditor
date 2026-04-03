using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.VaseRandomDataEntityData))]
	public class VaseRandomDataEntity : LogicEntity, IEntityData<FrostySdk.Ebx.VaseRandomDataEntityData>
	{
		public new FrostySdk.Ebx.VaseRandomDataEntityData Data => data as FrostySdk.Ebx.VaseRandomDataEntityData;
		public override string DisplayName => "VaseRandomData";

		public VaseRandomDataEntity(FrostySdk.Ebx.VaseRandomDataEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

