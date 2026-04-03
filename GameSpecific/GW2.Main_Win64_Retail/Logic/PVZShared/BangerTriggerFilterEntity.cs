using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BangerTriggerFilterEntityData))]
	public class BangerTriggerFilterEntity : TriggerFilterEntity, IEntityData<FrostySdk.Ebx.BangerTriggerFilterEntityData>
	{
		public new FrostySdk.Ebx.BangerTriggerFilterEntityData Data => data as FrostySdk.Ebx.BangerTriggerFilterEntityData;
		public override string DisplayName => "BangerTriggerFilter";

		public BangerTriggerFilterEntity(FrostySdk.Ebx.BangerTriggerFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

