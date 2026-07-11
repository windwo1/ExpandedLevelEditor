using Frosty.Controls;
using Frosty.Core;
using FrostySdk.Managers.Entries;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LevelEditorPlugin.Windows
{
    public class AddObjectEventArgs
    {
        public EbxAssetEntry Asset { get; private set; }
        public int Count { get; private set; }

        public AddObjectEventArgs(EbxAssetEntry asset, int count)
        {
            Asset = asset;
            Count = count;
        }
    }

    /// <summary>
    /// Interaction logic for AddObjectWindow.xaml
    /// </summary>
    public partial class AddObjectWindow : FrostyDockableWindow
    {
        public event EventHandler<AddObjectEventArgs> SelectedAsset;

        private int count;
        private bool valid = true;

        private const int maxCount = 100;
        private const int minCount = 1;

        public AddObjectWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetDataExplorerTypes();
            SetCount();
        }

        private void ObjTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetDataExplorerTypes();
        }

        private void DataExplorer_SelectedAssetDoubleClick(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void CountText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetCount();
        }

        private void SetCount()
        {
            try
            {
                count = int.Parse(countText.Text);
                Validate();
            }
            catch { Invalidate(); }

            if (count > maxCount) countText.Text = maxCount.ToString();
            if (count < minCount) countText.Text = minCount.ToString();
        }

        private void Invalidate()
        {
            valid = false;
            createBtn.IsEnabled = false;
        }

        private void Validate()
        {
            valid = true;
            createBtn.IsEnabled = true;
        }

        private void Create()
        {
            if (!valid)
                return;

            string assetType = GetComboBoxType();
            if (dataExplorer.SelectedAsset == null || dataExplorer.SelectedAsset.Type != assetType)
            {
                FrostyMessageBox.Show("Selected asset must be type " + assetType);
                return;
            }

            SelectedAsset?.Invoke(this, new AddObjectEventArgs(dataExplorer.SelectedAsset as EbxAssetEntry, count));
            Close();
        }

        private void SetDataExplorerTypes()
        {
            if (dataExplorer == null)
                return;

            string assetType = GetComboBoxType();

            dataExplorer.ItemsSource = App.AssetManager.EnumerateEbx(type: assetType);
            tbType.Text = $"({assetType})";
        }

        private string GetComboBoxType()
        {
            switch (objTypeComboBox.SelectedIndex)
            {
                case 0: return "ObjectBlueprint";
                case 1: return "SpatialPrefabBlueprint";
            }

            return "";
        }
    }
}
