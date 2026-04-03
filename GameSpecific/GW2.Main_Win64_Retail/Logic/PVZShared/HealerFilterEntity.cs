using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.HealerFilterEntityData))]
	public class HealerFilterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.HealerFilterEntityData>
	{
		public new FrostySdk.Ebx.HealerFilterEntityData Data => data as FrostySdk.Ebx.HealerFilterEntityData;
		public override string DisplayName => "HealerFilter";

		public HealerFilterEntity(FrostySdk.Ebx.HealerFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

