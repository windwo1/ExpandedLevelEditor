using Frosty.Controls;
using Frosty.Core;
using Frosty.Core.Controls;
using FrostySdk.Interfaces;
using LevelEditorPlugin.Editors;
using System.Windows.Media;

namespace LevelEditorPlugin.Definitions
{
    public class LevelDataAssetDefinition : BaseAssetDefinition
    {
        protected override ImageSource ImageIcon => Icons.LevelDataImageSource;
        protected override SvgImageData SvgIcon => Icons.LevelDataIcon;

        public override FrostyAssetEditor GetEditor(ILogger logger)
        {
            if (Config.Get<bool>("LevelEditorEnabled", true))
            {
                return new LevelEditor(logger);
            }

            return null;
        }
    }
}
