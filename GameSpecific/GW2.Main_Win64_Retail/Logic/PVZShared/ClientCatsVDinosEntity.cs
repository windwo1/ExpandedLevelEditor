using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientCatsVDinosEntityData))]
	public class ClientCatsVDinosEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientCatsVDinosEntityData>
	{
		public new FrostySdk.Ebx.ClientCatsVDinosEntityData Data => data as FrostySdk.Ebx.ClientCatsVDinosEntityData;
		public override string DisplayName => "ClientCatsVDinos";

		public ClientCatsVDinosEntity(FrostySdk.Ebx.ClientCatsVDinosEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

