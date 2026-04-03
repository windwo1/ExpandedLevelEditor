using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.UICostumeDataFilterEntityData))]
	public class UICostumeDataFilterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.UICostumeDataFilterEntityData>
	{
		public new FrostySdk.Ebx.UICostumeDataFilterEntityData Data => data as FrostySdk.Ebx.UICostumeDataFilterEntityData;
		public override string DisplayName => "UICostumeDataFilter";

		public UICostumeDataFilterEntity(FrostySdk.Ebx.UICostumeDataFilterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

