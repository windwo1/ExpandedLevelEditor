using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ClientRegionSelectEntityData))]
	public class ClientRegionSelectEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ClientRegionSelectEntityData>
	{
		public new FrostySdk.Ebx.ClientRegionSelectEntityData Data => data as FrostySdk.Ebx.ClientRegionSelectEntityData;
		public override string DisplayName => "ClientRegionSelect";

		public ClientRegionSelectEntity(FrostySdk.Ebx.ClientRegionSelectEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

