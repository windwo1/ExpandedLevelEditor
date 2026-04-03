using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.StaticModelTriggerFilterEntityData))]
	public class StaticModelTriggerFilterEntity : TriggerFilterEntity, IEntityData<FrostySdk.Ebx.StaticModelTriggerFilterEntityData>
	{
		public new FrostySdk.Ebx.StaticModelTriggerFilterEntityData Data => data as FrostySdk.Ebx.StaticModelTriggerFilterEntityData;
		public override string DisplayName => "StaticModelTriggerFilter";

		public StaticModelTriggerFilterEntity(FrostySdk.Ebx.StaticModelTriggerFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

