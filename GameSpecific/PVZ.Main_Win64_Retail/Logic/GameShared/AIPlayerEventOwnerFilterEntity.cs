using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AIPlayerEventOwnerFilterEntityData))]
	public class AIPlayerEventOwnerFilterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AIPlayerEventOwnerFilterEntityData>
	{
		public new FrostySdk.Ebx.AIPlayerEventOwnerFilterEntityData Data => data as FrostySdk.Ebx.AIPlayerEventOwnerFilterEntityData;
		public override string DisplayName => "AIPlayerEventOwnerFilter";

		public AIPlayerEventOwnerFilterEntity(FrostySdk.Ebx.AIPlayerEventOwnerFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

