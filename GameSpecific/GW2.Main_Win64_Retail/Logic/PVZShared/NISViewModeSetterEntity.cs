using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.NISViewModeSetterEntityData))]
	public class NISViewModeSetterEntity : LogicEntity, IEntityData<FrostySdk.Ebx.NISViewModeSetterEntityData>
	{
		public new FrostySdk.Ebx.NISViewModeSetterEntityData Data => data as FrostySdk.Ebx.NISViewModeSetterEntityData;
		public override string DisplayName => "NISViewModeSetter";

		public NISViewModeSetterEntity(FrostySdk.Ebx.NISViewModeSetterEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

