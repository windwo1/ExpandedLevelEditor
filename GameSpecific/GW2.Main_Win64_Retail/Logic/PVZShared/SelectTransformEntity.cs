using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.SelectTransformEntityData))]
	public class SelectTransformEntity : LogicEntity, IEntityData<FrostySdk.Ebx.SelectTransformEntityData>
	{
		public new FrostySdk.Ebx.SelectTransformEntityData Data => data as FrostySdk.Ebx.SelectTransformEntityData;
		public override string DisplayName => "SelectTransform";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public SelectTransformEntity(FrostySdk.Ebx.SelectTransformEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

