using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.LanguageEntityData))]
	public class LanguageEntity : LogicEntity, IEntityData<FrostySdk.Ebx.LanguageEntityData>
	{
		public new FrostySdk.Ebx.LanguageEntityData Data => data as FrostySdk.Ebx.LanguageEntityData;
		public override string DisplayName => "Language";

		public LanguageEntity(FrostySdk.Ebx.LanguageEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

