using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TriggerFilterEntityData))]
	public class TriggerFilterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.TriggerFilterEntityData>
	{
		public new FrostySdk.Ebx.TriggerFilterEntityData Data => data as FrostySdk.Ebx.TriggerFilterEntityData;
		public override string DisplayName => "TriggerFilter";

		public TriggerFilterEntity(FrostySdk.Ebx.TriggerFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

