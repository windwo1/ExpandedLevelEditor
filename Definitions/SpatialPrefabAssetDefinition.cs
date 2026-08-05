using Frosty.Controls;
using Frosty.Core;
using Frosty.Core.Controls;
using FrostySdk.Interfaces;
using LevelEditorPlugin.Editors;
using System.Windows.Media;

namespace LevelEditorPlugin.Definitions
{
    public class SpatialPrefabAssetDefinition : BaseAssetDefinition
    {
        protected override ImageSource ImageIcon => Icons.SpatialBlueprintImageSource;
        protected override SvgImageData SvgIcon => Icons.SpatialBlueprintIcon;

        public override FrostyAssetEditor GetEditor(ILogger logger)
        {
            if (Config.Get<bool>("SpatialPrefabEditorEnabled", true))
            {
                return new SpatialPrefabEditor(logger);
            }

            return null;
        }
    }
}
