using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ConditionalUintEntityData))]
	public class ConditionalUintEntity : ConditionalStateEntity, IEntityData<FrostySdk.Ebx.ConditionalUintEntityData>
	{
		public new FrostySdk.Ebx.ConditionalUintEntityData Data => data as FrostySdk.Ebx.ConditionalUintEntityData;
		public override string DisplayName => "ConditionalUint";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public ConditionalUintEntity(FrostySdk.Ebx.ConditionalUintEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

