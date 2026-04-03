using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.PropertyCastEntityData))]
	public class PropertyCastEntity : LogicEntity, IEntityData<FrostySdk.Ebx.PropertyCastEntityData>
	{
		public new FrostySdk.Ebx.PropertyCastEntityData Data => data as FrostySdk.Ebx.PropertyCastEntityData;
		public override string DisplayName => "PropertyCast";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public PropertyCastEntity(FrostySdk.Ebx.PropertyCastEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

