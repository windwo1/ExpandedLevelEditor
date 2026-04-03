using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.CapturePointLocationEntityData))]
	public class CapturePointLocationEntity : LogicEntity, IEntityData<FrostySdk.Ebx.CapturePointLocationEntityData>
	{
		public new FrostySdk.Ebx.CapturePointLocationEntityData Data => data as FrostySdk.Ebx.CapturePointLocationEntityData;
		public override string DisplayName => "CapturePointLocation";

		public CapturePointLocationEntity(FrostySdk.Ebx.CapturePointLocationEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

