using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.StreamingInstallEntityData))]
	public class StreamingInstallEntity : LogicEntity, IEntityData<FrostySdk.Ebx.StreamingInstallEntityData>
	{
		public new FrostySdk.Ebx.StreamingInstallEntityData Data => data as FrostySdk.Ebx.StreamingInstallEntityData;
		public override string DisplayName => "StreamingInstall";

		public StreamingInstallEntity(FrostySdk.Ebx.StreamingInstallEntityData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

