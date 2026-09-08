using Frosty.Core;
using LevelEditorPlugin.Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LevelEditorPlugin.Editors
{
    public class LayersViewModel : Controls.IDockableItem, INotifyPropertyChanged
    {
        public string Header => "Layers";
        public string UniqueId => "UID_LevelEditor_Layers";
        public string Icon => "Images/Layers.png";
        public IEnumerable<Layers.SceneLayer> Layers
        {
            get => layers;
            set
            {
                if (layers != value)
                {
                    layers = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private IEnumerable<Layers.SceneLayer> layers;

        private IEditorProvider owner;

        public LayersViewModel(IEditorProvider inOwner)
        {
            owner = inOwner;

            UpdateLayers();

            List<Layers.SceneLayer> layers = new List<Layers.SceneLayer>();
            owner.RootLayer.CollectLayers(layers);

            owner.RootLayer.SelectionChanged += SelectedLayerChanged;
            foreach (SceneLayer layer in layers)
                layer.SelectionChanged += SelectedLayerChanged;

            owner.RootLayer.LayerModified += RootLayer_LayerModified;
        }

        private void RootLayer_LayerModified(object sender, EventArgs e)
        {
            UpdateLayers();
        }

        private void SelectedLayerChanged(object sender, Layers.LayerSelectionChangedEventArgs e)
        {
            if (e.Selected)
                owner.SelectLayer(e.Layer);
        }

        private void UpdateLayers()
        {
            Layers = new List<Layers.SceneLayer> { owner.RootLayer };
        }

        #region -- INotifyPropertyChanged --
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
