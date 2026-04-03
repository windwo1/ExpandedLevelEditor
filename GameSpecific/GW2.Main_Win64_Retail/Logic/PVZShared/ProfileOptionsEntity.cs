using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ProfileOptionsEntityData))]
	public class ProfileOptionsEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ProfileOptionsEntityData>
	{
		public new FrostySdk.Ebx.ProfileOptionsEntityData Data => data as FrostySdk.Ebx.ProfileOptionsEntityData;
		public override string DisplayName => "ProfileOptions";

		public ProfileOptionsEntity(FrostySdk.Ebx.ProfileOptionsEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

