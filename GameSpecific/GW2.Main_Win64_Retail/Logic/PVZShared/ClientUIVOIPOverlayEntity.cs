using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientUIVOIPOverlayEntityData))]
	public class ClientUIVOIPOverlayEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientUIVOIPOverlayEntityData>
	{
		public new FrostySdk.Ebx.ClientUIVOIPOverlayEntityData Data => data as FrostySdk.Ebx.ClientUIVOIPOverlayEntityData;
		public override string DisplayName => "ClientUIVOIPOverlay";

		public ClientUIVOIPOverlayEntity(FrostySdk.Ebx.ClientUIVOIPOverlayEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

