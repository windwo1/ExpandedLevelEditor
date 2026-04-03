using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PVZHumanPlayerProxyEntityData))]
	public class PVZHumanPlayerProxyEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PVZHumanPlayerProxyEntityData>
	{
		public new FrostySdk.Ebx.PVZHumanPlayerProxyEntityData Data => data as FrostySdk.Ebx.PVZHumanPlayerProxyEntityData;
		public override string DisplayName => "PVZHumanPlayerProxy";

		public PVZHumanPlayerProxyEntity(FrostySdk.Ebx.PVZHumanPlayerProxyEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

