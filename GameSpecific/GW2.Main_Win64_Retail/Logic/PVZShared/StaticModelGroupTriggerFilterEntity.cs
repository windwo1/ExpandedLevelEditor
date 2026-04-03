using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.StaticModelGroupTriggerFilterEntityData))]
	public class StaticModelGroupTriggerFilterEntity : TriggerFilterEntity, IEntityData<FrostySdk.Ebx.StaticModelGroupTriggerFilterEntityData>
	{
		public new FrostySdk.Ebx.StaticModelGroupTriggerFilterEntityData Data => data as FrostySdk.Ebx.StaticModelGroupTriggerFilterEntityData;
		public override string DisplayName => "StaticModelGroupTriggerFilter";

		public StaticModelGroupTriggerFilterEntity(FrostySdk.Ebx.StaticModelGroupTriggerFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

