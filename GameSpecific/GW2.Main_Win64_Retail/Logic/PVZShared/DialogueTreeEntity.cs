using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.DialogueTreeEntityData))]
	public class DialogueTreeEntity : LogicEntity, IEntityData<FrostySdk.Ebx.DialogueTreeEntityData>
	{
		public new FrostySdk.Ebx.DialogueTreeEntityData Data => data as FrostySdk.Ebx.DialogueTreeEntityData;
		public override string DisplayName => "DialogueTree";

		public DialogueTreeEntity(FrostySdk.Ebx.DialogueTreeEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

