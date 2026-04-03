using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UIFirstPartyEntityData))]
	public class UIFirstPartyEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UIFirstPartyEntityData>
	{
		public new FrostySdk.Ebx.UIFirstPartyEntityData Data => data as FrostySdk.Ebx.UIFirstPartyEntityData;
		public override string DisplayName => "UIFirstParty";

		public UIFirstPartyEntity(FrostySdk.Ebx.UIFirstPartyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

