using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.AbilityInfoEntityData))]
	public class AbilityInfoEntity : LogicEntity, IEntityData<FrostySdk.Ebx.AbilityInfoEntityData>
	{
		public new FrostySdk.Ebx.AbilityInfoEntityData Data => data as FrostySdk.Ebx.AbilityInfoEntityData;
		public override string DisplayName => "AbilityInfo";

		public AbilityInfoEntity(FrostySdk.Ebx.AbilityInfoEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

