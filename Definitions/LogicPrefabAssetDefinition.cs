using Frosty.Controls;
using Frosty.Core;
using Frosty.Core.Controls;
using FrostySdk.Interfaces;
using LevelEditorPlugin.Editors;
using System.Windows.Media;

namespace LevelEditorPlugin.Definitions
{
    public class LogicPrefabAssetDefinition : BaseAssetDefinition
    {
        protected override ImageSource ImageIcon => Icons.LogicBlueprintImageSource;
        protected override SvgImageData SvgIcon => Icons.LogicBlueprintIcon;

        public override FrostyAssetEditor GetEditor(ILogger logger)
        {
            if (Config.Get<bool>("LogicPrefabEditorEnabled", false))
            {
                return new LogicPrefabEditor(logger);
            }

            return null;
        }
    }
}
