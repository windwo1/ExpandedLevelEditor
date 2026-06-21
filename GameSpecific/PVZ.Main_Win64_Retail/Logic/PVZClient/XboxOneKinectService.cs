using System.Collections.Generic;

namespace LevelEditorPlugin.Entities
{
	[EntityBinding(DataType = typeof(FrostySdk.Ebx.XboxOneKinectServiceData))]
	public class XboxOneKinectService : LogicEntity, IEntityData<FrostySdk.Ebx.XboxOneKinectServiceData>
	{
		public new FrostySdk.Ebx.XboxOneKinectServiceData Data => data as FrostySdk.Ebx.XboxOneKinectServiceData;
		public override string DisplayName => "XboxOneKinectService";

		public XboxOneKinectService(FrostySdk.Ebx.XboxOneKinectServiceData inData, Entity inParent)
			: base(inData, inParent)
		{
		}
	}
}

