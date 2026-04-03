using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.BinaryOpEntityData))]
	public class BinaryOpEntity : LogicEntity, IEntityData<FrostySdk.Ebx.BinaryOpEntityData>
	{
		public new FrostySdk.Ebx.BinaryOpEntityData Data => data as FrostySdk.Ebx.BinaryOpEntityData;
		public override string DisplayName => "BinaryOp";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public BinaryOpEntity(FrostySdk.Ebx.BinaryOpEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

