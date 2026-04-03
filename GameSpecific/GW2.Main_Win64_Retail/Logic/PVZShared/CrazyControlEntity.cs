using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CrazyControlEntityData))]
	public class CrazyControlEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CrazyControlEntityData>
	{
		public new FrostySdk.Ebx.CrazyControlEntityData Data => data as FrostySdk.Ebx.CrazyControlEntityData;
		public override string DisplayName => "CrazyControl";

		public CrazyControlEntity(FrostySdk.Ebx.CrazyControlEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

