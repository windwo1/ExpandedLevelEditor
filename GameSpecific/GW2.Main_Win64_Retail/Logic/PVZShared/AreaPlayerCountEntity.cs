using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AreaPlayerCountEntityData))]
	public class AreaPlayerCountEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AreaPlayerCountEntityData>
	{
		public new FrostySdk.Ebx.AreaPlayerCountEntityData Data => data as FrostySdk.Ebx.AreaPlayerCountEntityData;
		public override string DisplayName => "AreaPlayerCount";

		public AreaPlayerCountEntity(FrostySdk.Ebx.AreaPlayerCountEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

