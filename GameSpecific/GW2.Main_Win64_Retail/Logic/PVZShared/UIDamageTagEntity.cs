using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIDamageTagEntityData))]
	public class UIDamageTagEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIDamageTagEntityData>
	{
		public new FrostySdk.Ebx.UIDamageTagEntityData Data => data as FrostySdk.Ebx.UIDamageTagEntityData;
		public override string DisplayName => "UIDamageTag";

		public UIDamageTagEntity(FrostySdk.Ebx.UIDamageTagEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

