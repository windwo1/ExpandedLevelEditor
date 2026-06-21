using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZCharacterSpawnReferenceObjectData))]
	public class PVZCharacterSpawnReferenceObject : CharacterSpawnReferenceObject, IEntityData<FrostySdk.Ebx.PVZCharacterSpawnReferenceObjectData>
	{
		public new FrostySdk.Ebx.PVZCharacterSpawnReferenceObjectData Data => data as FrostySdk.Ebx.PVZCharacterSpawnReferenceObjectData;

		public PVZCharacterSpawnReferenceObject(FrostySdk.Ebx.PVZCharacterSpawnReferenceObjectData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

