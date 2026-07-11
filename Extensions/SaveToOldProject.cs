using Frosty.Core;
using Frosty.Core.Controls;
using Frosty.Core.Handlers;
using Frosty.Core.Mod;
using FrostySdk;
using FrostySdk.IO;
using FrostySdk.Managers.Entries;
using FrostySdk.Resources;
using LevelEditorPlugin.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LevelEditorPlugin.Extensions
{
    public class SaveToOldProject : MenuExtension
    {
        public override string TopLevelMenuName => "Developer";
        public override string MenuItemName => "Save project as old (for 1.0.6.3)";

        private const ulong Magic = 0x00005954534F5246;
        private const uint FormatVersion = 14;

        public override RelayCommand MenuItemClicked => new RelayCommand((o) =>
        {
            var sfd = new FrostySaveFileDialog("Save Old Project", "*.fbproject (FrostyProject)|*.fbproject", "Project");
            if (!sfd.ShowDialog())
                return;

            string file = sfd.FileName;
            var currentProject = (Application.Current.MainWindow as FrostyEditor.Windows.MainWindow).Project;
            using (var writer = new NativeWriter(new FileStream(file, FileMode.Create)))
            {
                writer.Write(Magic);
                writer.Write(FormatVersion);
                writer.WriteNullTerminatedString(currentProject.Profile);
                writer.Write(DateTime.Now.Ticks);
                writer.Write(DateTime.Now.Ticks);
                writer.Write(currentProject.gameVersion);

                writer.WriteNullTerminatedString(currentProject.ModSettings.Title);
                writer.WriteNullTerminatedString(currentProject.ModSettings.Author);
                writer.WriteNullTerminatedString(currentProject.ModSettings.Category);
                writer.WriteNullTerminatedString(currentProject.ModSettings.Version);
                writer.WriteNullTerminatedString(currentProject.ModSettings.Description);

                if (currentProject.ModSettings.Icon != null && currentProject.ModSettings.Icon.Length != 0)
                {
                    writer.Write(currentProject.ModSettings.Icon.Length);
                    writer.Write(currentProject.ModSettings.Icon);
                }
                else
                {
                    writer.Write(0);
                }

                for (int i = 0; i < 4; i++)
                {
                    byte[] buf = currentProject.ModSettings.GetScreenshot(i);
                    if (buf != null && buf.Length != 0)
                    {
                        writer.Write(buf.Length);
                        writer.Write(buf);
                    }
                    else
                    {
                        writer.Write(0);
                    }
                }

                // -----------------------------------------------------------------------------
                // added data
                // -----------------------------------------------------------------------------

                // @todo: superbundles
                writer.Write(0);

                // bundles
                long sizePosition = writer.Position;
                writer.Write(0xDEADBEEF);

                int count = 0;
                foreach (BundleEntry entry in App.AssetManager.EnumerateBundles(modifiedOnly: true))
                {
                    if (entry.Added)
                    {
                        writer.WriteNullTerminatedString(entry.Name);
                        writer.WriteNullTerminatedString(App.AssetManager.GetSuperBundle(entry.SuperBundleId).Name);
                        writer.Write((int)entry.Type);
                        count++;
                    }
                }

                writer.Position = sizePosition;
                writer.Write(count);
                writer.Position = writer.Length;

                // ebx
                sizePosition = writer.Position;
                writer.Write(0xDEADBEEF);

                count = 0;
                foreach (EbxAssetEntry entry in App.AssetManager.EnumerateEbx(modifiedOnly: true))
                {
                    if (entry.IsAdded)
                    {
                        writer.WriteNullTerminatedString(entry.Name);
                        writer.Write(entry.Guid);
                        count++;
                    }
                }

                writer.Position = sizePosition;
                writer.Write(count);
                writer.Position = writer.Length;

                // res
                sizePosition = writer.Position;
                writer.Write(0xDEADBEEF);

                count = 0;
                foreach (ResAssetEntry entry in App.AssetManager.EnumerateRes(modifiedOnly: true))
                {
                    if (entry.IsAdded)
                    {
                        writer.WriteNullTerminatedString(entry.Name);
                        writer.Write(entry.ResRid);
                        writer.Write(entry.ResType);
                        writer.Write(entry.ResMeta);
                        count++;
                    }
                }

                writer.Position = sizePosition;
                writer.Write(count);
                writer.Position = writer.Length;

                // chunks
                sizePosition = writer.Position;
                writer.Write(0xDEADBEEF);

                count = 0;
                foreach (ChunkAssetEntry entry in App.AssetManager.EnumerateChunks(modifiedOnly: true))
                {
                    if (entry.IsAdded)
                    {
                        writer.Write(entry.Id);
                        writer.Write(entry.H32);
                        count++;
                    }
                }

                writer.Position = sizePosition;
                writer.Write(count);
                writer.Position = writer.Length;

                // -----------------------------------------------------------------------------
                // modified data
                // -----------------------------------------------------------------------------

                // ebx
                sizePosition = writer.Position;
                writer.Write(0xDEADBEEF);

                count = 0;
                foreach (EbxAssetEntry entry in App.AssetManager.EnumerateEbx(modifiedOnly: true, includeLinked: true))
                {
                    writer.WriteNullTerminatedString(entry.Name);
                    SaveLinkedAssets(entry, writer);

                    // bundles the asset has been added to
                    writer.Write(entry.AddedBundles.Count);
                    foreach (int bid in entry.AddedBundles)
                        writer.WriteNullTerminatedString(App.AssetManager.GetBundleEntry(bid).Name);

                    // if the asset has been modified
                    writer.Write(entry.HasModifiedData);
                    if (entry.HasModifiedData)
                    {
                        // mark asset as only transient modified
                        writer.Write(entry.ModifiedEntry.IsTransientModified);
                        writer.WriteNullTerminatedString(entry.ModifiedEntry.UserData);

                        ModifiedResource modifiedResource = entry.ModifiedEntry.DataObject as ModifiedResource;
                        byte[] buf = null;
                        bool bCustomHandler = modifiedResource != null;

                        if (bCustomHandler)
                        {
                            // asset is using a custom handler
                            buf = modifiedResource.Save();
                        }
                        else
                        {
                            // asset is using just regular data
                            EbxAsset asset = entry.ModifiedEntry.DataObject as EbxAsset;
                            using (EbxBaseWriter ebxWriter = EbxBaseWriter.CreateProjectWriter(new MemoryStream(), EbxWriteFlags.IncludeTransient))
                            {
                                ebxWriter.WriteAsset(asset);
                                buf = ebxWriter.ToByteArray();
                            }
                        }

                        writer.Write(bCustomHandler);
                        writer.Write(buf.Length);
                        writer.Write(buf);
                    }

                    entry.IsDirty = false;

                    count++;
                }

                writer.Position = sizePosition;
                writer.Write(count);
                writer.Position = writer.Length;

                // res
                sizePosition = writer.Position;
                writer.Write(0xDEADBEEF);

                count = 0;
                foreach (ResAssetEntry entry in App.AssetManager.EnumerateRes(modifiedOnly: true))
                {
                    writer.WriteNullTerminatedString(entry.Name);
                    SaveLinkedAssets(entry, writer);

                    // bundles the asset has been added to
                    writer.Write(entry.AddedBundles.Count);
                    foreach (int bid in entry.AddedBundles)
                        writer.WriteNullTerminatedString(App.AssetManager.GetBundleEntry(bid).Name);

                    // if the asset has been modified
                    writer.Write(entry.HasModifiedData);
                    if (entry.HasModifiedData)
                    {
                        writer.Write(entry.ModifiedEntry.Sha1);
                        writer.Write(entry.ModifiedEntry.OriginalSize);
                        if (entry.ModifiedEntry.ResMeta != null)
                        {
                            writer.Write(entry.ModifiedEntry.ResMeta.Length);
                            writer.Write(entry.ModifiedEntry.ResMeta);
                        }
                        else
                        {
                            // no res meta
                            writer.Write(0);
                        }
                        writer.WriteNullTerminatedString(entry.ModifiedEntry.UserData);

                        byte[] buffer = entry.ModifiedEntry.Data;
                        if (entry.ModifiedEntry.DataObject != null)
                        {
                            ModifiedResource md = entry.ModifiedEntry.DataObject as ModifiedResource;
                            buffer = md.Save();
                        }

                        writer.Write(buffer.Length);
                        writer.Write(buffer);
                    }

                    entry.IsDirty = false;

                    count++;
                }

                writer.Position = sizePosition;
                writer.Write(count);
                writer.Position = writer.Length;

                // chunks
                sizePosition = writer.Position;
                writer.Write(0xDEADBEEF);

                count = 0;
                foreach (ChunkAssetEntry entry in App.AssetManager.EnumerateChunks(modifiedOnly: true))
                {
                    writer.Write(entry.Id);

                    // bundles the asset has been added to
                    writer.Write(entry.AddedBundles.Count);
                    foreach (int bid in entry.AddedBundles)
                        writer.WriteNullTerminatedString(App.AssetManager.GetBundleEntry(bid).Name);

                    writer.Write(entry.HasModifiedData ? entry.ModifiedEntry.FirstMip : entry.FirstMip);
                    writer.Write(entry.HasModifiedData ? entry.ModifiedEntry.H32 : entry.H32);

                    // if the asset has been modified
                    writer.Write(entry.HasModifiedData);
                    if (entry.HasModifiedData)
                    {
                        writer.Write(entry.ModifiedEntry.Sha1);
                        writer.Write(entry.ModifiedEntry.LogicalOffset);
                        writer.Write(entry.ModifiedEntry.LogicalSize);
                        writer.Write(entry.ModifiedEntry.RangeStart);
                        writer.Write(entry.ModifiedEntry.RangeEnd);
                        writer.Write(entry.ModifiedEntry.AddToChunkBundle);
                        writer.WriteNullTerminatedString(entry.ModifiedEntry.UserData);

                        writer.Write(entry.ModifiedEntry.Data.Length);
                        writer.Write(entry.ModifiedEntry.Data);
                    }

                    entry.IsDirty = false;

                    count++;
                }

                writer.Position = sizePosition;
                writer.Write(count);
                writer.Position = writer.Length;

                // custom actions
                sizePosition = writer.Position;
                writer.Write(0xDEADBEEF);

                count = 0;
                ICustomAssetCustomActionHandler legacyHandler = new LegacyCustomActionHandler();
                legacyHandler.SaveToProject(writer);

                writer.Position = sizePosition;
                writer.Write(1);
                writer.Position = writer.Length;

                currentProject.ModSettings.ClearDirtyFlag();
            }

            App.Logger.Log("Successfully saved 1.0.6.3 project to " + new FileInfo(file).Name);
        });

        private void SaveLinkedAssets(AssetEntry entry, NativeWriter writer)
        {
            writer.Write(entry.LinkedAssets.Count);
            foreach (AssetEntry linkedEntry in entry.LinkedAssets)
            {
                writer.WriteNullTerminatedString(linkedEntry.AssetType);
                if (linkedEntry is ChunkAssetEntry assetEntry)
                    writer.Write(assetEntry.Id);
                else
                    writer.WriteNullTerminatedString(linkedEntry.Name);
            }
        }
    }
}
