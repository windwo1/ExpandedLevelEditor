using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.FloatProviderEntityData))]
	public class FloatProviderEntity : ProviderEntity, IEntityData<FrostySdk.Ebx.FloatProviderEntityData>
	{
		public new FrostySdk.Ebx.FloatProviderEntityData Data => data as FrostySdk.Ebx.FloatProviderEntityData;
		public override string DisplayName => "FloatProvider";
		public override FrostySdk.Ebx.Realm Realm => Data.Realm;

		public FloatProviderEntity(FrostySdk.Ebx.FloatProviderEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

