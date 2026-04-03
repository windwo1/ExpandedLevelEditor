using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UnlockListInfoEntityData))]
	public class UnlockListInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UnlockListInfoEntityData>
	{
		public new FrostySdk.Ebx.UnlockListInfoEntityData Data => data as FrostySdk.Ebx.UnlockListInfoEntityData;
		public override string DisplayName => "UnlockListInfo";

		public UnlockListInfoEntity(FrostySdk.Ebx.UnlockListInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

