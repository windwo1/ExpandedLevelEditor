using Frosty.Controls;
using Frosty.Core;
using Frosty.Core.Controls;
using FrostySdk.Interfaces;
using LevelEditorPlugin.Editors;
using System.Windows.Media;

namespace LevelEditorPlugin.Definitions
{
    public class DetachedSubWorldDataAssetDefinition : BaseAssetDefinition
    {
        protected override ImageSource ImageIcon => Icons.DetachedSubWorldImageSource;
        protected override SvgImageData SvgIcon => Icons.DetachedSubWorldIcon;

        public override FrostyAssetEditor GetEditor(ILogger logger)
        {
            if (Config.Get<bool>("SubWorldEditorEnabled", false))
            {
                App.Logger.Log(Config.Get<bool>("SubWorldEditorEnabled", false).ToString());
                return new LevelEditor(logger);
            }

            return null;
        }
    }
}
