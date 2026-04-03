using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.TrcNotifyListenerEntityData))]
	public class TrcNotifyListenerEntity : LogicEntity, IEntityData<FrostySdk.Ebx.TrcNotifyListenerEntityData>
	{
		public new FrostySdk.Ebx.TrcNotifyListenerEntityData Data => data as FrostySdk.Ebx.TrcNotifyListenerEntityData;
		public override string DisplayName => "TrcNotifyListener";

		public TrcNotifyListenerEntity(FrostySdk.Ebx.TrcNotifyListenerEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

