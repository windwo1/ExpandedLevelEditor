using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ConsumableControlEntityData))]
	public class ConsumableControlEntity : LogicEntity, IEntityData<FrostySdk.Ebx.ConsumableControlEntityData>
	{
		public new FrostySdk.Ebx.ConsumableControlEntityData Data => data as FrostySdk.Ebx.ConsumableControlEntityData;
		public override string DisplayName => "ConsumableControl";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public ConsumableControlEntity(FrostySdk.Ebx.ConsumableControlEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

