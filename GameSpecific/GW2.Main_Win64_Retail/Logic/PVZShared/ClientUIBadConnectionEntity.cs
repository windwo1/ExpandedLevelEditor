using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientUIBadConnectionEntityData))]
	public class ClientUIBadConnectionEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientUIBadConnectionEntityData>
	{
		public new FrostySdk.Ebx.ClientUIBadConnectionEntityData Data => data as FrostySdk.Ebx.ClientUIBadConnectionEntityData;
		public override string DisplayName => "ClientUIBadConnection";

		public ClientUIBadConnectionEntity(FrostySdk.Ebx.ClientUIBadConnectionEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

