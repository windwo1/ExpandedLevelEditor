using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CustomizationEntityData))]
	public class CustomizationEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CustomizationEntityData>
	{
		public new FrostySdk.Ebx.CustomizationEntityData Data => data as FrostySdk.Ebx.CustomizationEntityData;
		public override string DisplayName => "Customization";

		public CustomizationEntity(FrostySdk.Ebx.CustomizationEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

