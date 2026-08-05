using Frosty.Controls;
using Frosty.Core;
using Frosty.Core.Controls;
using FrostySdk.Interfaces;
using LevelEditorPlugin.Editors;
using System.Windows.Media;

namespace LevelEditorPlugin.Definitions
{
    public class ObjectBlueprintAssetDefinition : BaseAssetDefinition
    {
        protected override ImageSource ImageIcon => Icons.ObjectBlueprintImageSource;
        protected override SvgImageData SvgIcon => Icons.ObjectBlueprintIcon;

        public override FrostyAssetEditor GetEditor(ILogger logger)
        {
            if (Config.Get<bool>("ObjectBlueprintEditorEnabled", false))
            {
                return new ObjectBlueprintEditor(logger);
            }

            return null;
        }
    }
}
