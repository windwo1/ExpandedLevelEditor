using Frosty.Controls;
using Frosty.Core;
using Frosty.Core.Viewport;
using FrostySdk;
using FrostySdk.Ebx;
using FrostySdk.IO;
using FrostySdk.Managers;
using FrostySdk.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BundleType = FrostySdk.Managers.BundleType;

namespace LevelEditorPlugin.Managers
{
    public class BundleManager
    {
        #region -- Singleton --

        public static BundleManager Instance { get; private set; } = new BundleManager();
        private BundleManager() { }

        #endregion

        private EbxAssetEntry meshVarDb;
        private MeshVariationMaterial materialRef;
        private HashSet<string> managedAssets = new HashSet<string>();

        public void Manage(List<int> bundles, EbxAssetEntry rootEntry, MeshVariationMaterial material = null)
        {
            bundles.Sort();
            string cacheKey = $"{string.Join(",", bundles)}:{rootEntry.Name}";

            if (!managedAssets.Add(cacheKey))
                return;

            foreach (int bundle in bundles)
            {
                if (rootEntry.IsInBundle(bundle))
                    return;
            }

            FindMeshVarDb(bundles);

            materialRef = material;
            Manage(bundles, rootEntry, new HashSet<EbxAssetEntry>());
        }

        private void Manage(List<int> bundles, EbxAssetEntry rootEntry, HashSet<EbxAssetEntry> visited)
        {
            if (!visited.Add(rootEntry))
                return;

            if (!HasSubLevelBundles(rootEntry))
                return;

            foreach (var bundle in bundles)
            {
                if (rootEntry.IsInBundle(bundle))
                    continue;

                rootEntry.AddedBundles.Add(bundle);
            }

            foreach (var guid in rootEntry.EnumerateDependencies())
            {
                var entry = App.AssetManager.GetEbxEntry(guid);
                bool contains = visited.Contains(entry);

                Manage(bundles, entry, visited);

                if (!contains)
                {
                    ManageRes(bundles, entry, visited);
                }
            }
        }

        private void ManageRes(List<int> bundles, EbxAssetEntry entry, HashSet<EbxAssetEntry> visited)
        {
            var asset = App.AssetManager.GetEbx(entry);
            object rootObject = asset.RootObject;

            if (rootObject is MeshAsset mesh)
            {
                var res = App.AssetManager.GetResEntry(mesh.MeshSetResource);
                var occluderRes = App.AssetManager.GetResEntry(mesh.OccluderMeshResource);

                ManageRes(bundles, res, entry);
                ManageRes(bundles, occluderRes, entry);

                var meshSet = App.AssetManager.GetResAs<MeshSetPlugin.Resources.MeshSet>(res);
                foreach (var lod in meshSet.Lods)
                {
                    var chunkEntry = App.AssetManager.GetChunkEntry(lod.ChunkId);

                    ManageChunk(bundles, chunkEntry, res);
                }

                var dbEntry = MeshVariationDb.GetVariations(entry.Guid);

                MeshVariation mv = null;
                if (dbEntry != null)
                {
                    mv = dbEntry.GetVariation(MeshVariationDbEntry.ROOT_VARIATION);
                }

                var materials = new List<MeshVariationDatabaseMaterial>();

                foreach (var matRef in mesh.Materials)
                {
                    var mat = matRef.Internal as FrostySdk.Ebx.MeshMaterial;
                    if (materialRef == null)
                    {
                        if (mv == null)
                            break;

                        int idx = mv.Materials.FindIndex(a => a.MaterialGuid == mat.GetInstanceGuid().ExportedGuid);
                        if (idx == -1)
                            continue;

                        ProcessMaterial(mv.Materials[idx], mat);
                    }
                    else
                    {
                        ProcessMaterial(materialRef, mat);
                    }
                }

                void ProcessMaterial(MeshVariationMaterial material, FrostySdk.Ebx.MeshMaterial mat)
                {
                    dynamic texParams = material.TextureParameters;
                    var matTexParams = new List<TextureShaderParameter>();

                    foreach (var texParam in texParams)
                    {
                        var texEntry = App.AssetManager.GetEbxEntry(texParam.Value.External.FileGuid);
                        Manage(bundles, texEntry, visited);
                        ManageRes(bundles, texEntry, visited);

                        matTexParams.Add(new TextureShaderParameter
                        {
                            ParameterName = texParam.ParameterName,
                            Value = texParam.Value,
                        });
                    }

                    materials.Add(new MeshVariationDatabaseMaterial
                    {
                        Material = new PointerRef(new EbxImportReference
                        {
                            FileGuid = entry.Guid,
                            ClassGuid = mat.GetInstanceGuid().ExportedGuid
                        }),
                        TextureParameters = matTexParams
                    });
                }

                if (meshVarDb != null)
                {
                    var dbAsset = App.AssetManager.GetEbx(meshVarDb);
                    var db = dbAsset.RootObject as MeshVariationDatabase;
                    bool hasEntry = db.Entries.Any(e => 
                        e.Mesh.External.FileGuid == entry.Guid && 
                        e.Mesh.External.ClassGuid == mesh.__InstanceGuid.ExportedGuid);

                    if (!hasEntry)
                    {
                        db.Entries.Add(new MeshVariationDatabaseEntry
                        {
                            Mesh = new PointerRef(new EbxImportReference
                            {
                                FileGuid = entry.Guid,
                                ClassGuid = mesh.__InstanceGuid.ExportedGuid
                            }),
                            Materials = materials
                        });

                        dbAsset.AddDependency(entry.Guid);
                        foreach (var texParam in materials.SelectMany(m => m.TextureParameters))
                        {
                            dbAsset.AddDependency(texParam.Value.External.FileGuid);
                        }

                        App.AssetManager.ModifyEbx(meshVarDb.Name, dbAsset);
                    }
                }
            }
            else if (rootObject is TextureAsset texture)
            {
                var res = App.AssetManager.GetResEntry(texture.Resource);
                ManageRes(bundles, res, entry);

                var textureRes = App.AssetManager.GetResAs<Texture>(res);
                var chunkEntry = App.AssetManager.GetChunkEntry(textureRes.ChunkId);
                ManageChunk(bundles, chunkEntry, res);
            }
            else if (rootObject is HavokAsset physics)
            {
                var res = App.AssetManager.GetResEntry(physics.Resource);
                ManageRes(bundles, res, entry);
            }

            // technically there should be a lot more resources to be managed
            // but we're only using this for the level editor to add objects
        }

        private void ManageRes(List<int> bundles, ResAssetEntry resEntry, AssetEntry linked)
        {
            if (resEntry == null)
                return;

            if (!HasSubLevelBundles(resEntry))
                return;

            linked.LinkAsset(resEntry);

            foreach (var bundle in bundles)
            {
                if (resEntry.IsInBundle(bundle))
                    continue;

                resEntry.AddedBundles.Add(bundle);
            }
        }

        private void ManageChunk(List<int> bundles, ChunkAssetEntry chunkEntry, AssetEntry linked)
        {
            if (chunkEntry == null)
                return;

            if (!HasSubLevelBundles(chunkEntry))
                return;

            linked.LinkAsset(chunkEntry);

            foreach (var bundle in bundles)
            {
                if (chunkEntry.IsInBundle(bundle))
                    continue;

                chunkEntry.AddedBundles.Add(bundle);
            }
        }

        private void FindMeshVarDb(List<int> bundles)
        {
            meshVarDb = null;

            foreach (var bundle in bundles)
            {
                foreach (var entry in App.AssetManager.EnumerateEbx("MeshVariationDatabase"))
                {
                    if (!entry.IsInBundle(bundle))
                        continue;

                    meshVarDb = entry;
                    return;
                }
            }
        }

        private bool HasSubLevelBundles(AssetEntry entry)
        {
            return entry.Bundles.Any(b => App.AssetManager.GetBundleEntry(b).Type == BundleType.SubLevel)
                || (entry.Bundles.Count == 0 && entry.IsAdded); // if it's newly created
        }
    }
}
