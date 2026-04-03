using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterEntityData))]
	public class PVZCharacterEntity : CharacterEntity, IEntityData<FrostySdk.Ebx.PVZCharacterEntityData>
	{
		public new FrostySdk.Ebx.PVZCharacterEntityData Data => data as FrostySdk.Ebx.PVZCharacterEntityData;

		public PVZCharacterEntity(FrostySdk.Ebx.PVZCharacterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

