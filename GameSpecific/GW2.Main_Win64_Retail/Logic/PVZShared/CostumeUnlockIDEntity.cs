using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CostumeUnlockIDEntityData))]
	public class CostumeUnlockIDEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CostumeUnlockIDEntityData>
	{
		public new FrostySdk.Ebx.CostumeUnlockIDEntityData Data => data as FrostySdk.Ebx.CostumeUnlockIDEntityData;
		public override string DisplayName => "CostumeUnlockID";

		public CostumeUnlockIDEntity(FrostySdk.Ebx.CostumeUnlockIDEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

