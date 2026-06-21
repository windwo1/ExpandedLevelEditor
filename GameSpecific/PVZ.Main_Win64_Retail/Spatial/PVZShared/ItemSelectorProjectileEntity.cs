using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.ItemSelectorProjectileEntityData))]
	public class ItemSelectorProjectileEntity : ExplosionPackEntity, IEntityData<FrostySdk.Ebx.ItemSelectorProjectileEntityData>
	{
		public new FrostySdk.Ebx.ItemSelectorProjectileEntityData Data => data as FrostySdk.Ebx.ItemSelectorProjectileEntityData;

		public ItemSelectorProjectileEntity(FrostySdk.Ebx.ItemSelectorProjectileEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

