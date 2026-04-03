using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIDamageTagInfoEntityData))]
	public class UIDamageTagInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIDamageTagInfoEntityData>
	{
		public new FrostySdk.Ebx.UIDamageTagInfoEntityData Data => data as FrostySdk.Ebx.UIDamageTagInfoEntityData;
		public override string DisplayName => "UIDamageTagInfo";

		public UIDamageTagInfoEntity(FrostySdk.Ebx.UIDamageTagInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

