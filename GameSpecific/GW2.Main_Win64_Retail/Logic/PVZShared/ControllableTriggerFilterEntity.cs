using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ControllableTriggerFilterEntityData))]
	public class ControllableTriggerFilterEntity : TriggerFilterEntity, IEntityData<FrostySdk.Ebx.ControllableTriggerFilterEntityData>
	{
		public new FrostySdk.Ebx.ControllableTriggerFilterEntityData Data => data as FrostySdk.Ebx.ControllableTriggerFilterEntityData;
		public override string DisplayName => "ControllableTriggerFilter";

		public ControllableTriggerFilterEntity(FrostySdk.Ebx.ControllableTriggerFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

