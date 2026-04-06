using Frosty.Controls;
using Frosty.Core;
using Frosty.Core.Controls;
using Frosty.Core.Screens;
using Frosty.Core.Viewport;
using FrostySdk;
using FrostySdk.IO;
using FrostySdk.Managers.Entries;
using LevelEditorPlugin.Assets;
using LevelEditorPlugin.Entities;
using SharpDX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using D3D11 = SharpDX.Direct3D11;

namespace LevelEditorPlugin.Render.Proxies
{
    public class ModelRenderProxy : RenderProxy
    {
        protected MeshRenderable renderData;
        protected int lodIndex;

        private ShaderPermutation permutation;
        private D3D11.Buffer pixelParameters;
        private List<D3D11.ShaderResourceView> pixelTextures = new List<D3D11.ShaderResourceView>();
        private MeshMaterial material;

        public static MeshMaterialCollection Materials;

        private static GeometryDeclarationDesc GeometryDecl = GeometryDeclarationDesc.Create(new GeometryDeclarationDesc.Element[]
        {
            new GeometryDeclarationDesc.Element
            {
                Usage = VertexElementUsage.Pos,
                Format = VertexElementFormat.Float3
            },
            new GeometryDeclarationDesc.Element
            {
                Usage = VertexElementUsage.Normal,
                Format = VertexElementFormat.Float3
            }
        });

        public ModelRenderProxy(RenderCreateState state, ISpatialEntity owner, MeshRenderable meshData)
            : base(owner)
        {
            renderData = meshData;

            RecalculateBoundingBox();

            // materials
            MeshAsset asset = null;
            if (OwnerEntity is MeshProxyEntity meshProxyEntity) asset = meshProxyEntity.Mesh;
            if (OwnerEntity is StaticModelEntity staticModelEntity) asset = staticModelEntity.Mesh;
            if (OwnerEntity is ClothEntity clothEntity) asset = clothEntity.Mesh;
            if (OwnerEntity is VegetationTreeEntity vegetationTreeEntity) asset = vegetationTreeEntity.Mesh;

            if (asset != null)
            {
                EbxAsset ebx = App.AssetManager.GetEbx(App.AssetManager.GetEbxEntry(asset.FileGuid));

                renderData.SetMaterials(state, new MeshMaterialCollection(ebx, new FrostySdk.Ebx.PointerRef()));
            }

            permutation = state.ShaderLibrary.GetFallbackShader();
            permutation.IsTwoSided = true;
            permutation.LoadShaders(state.Device);
            permutation.AssignParameters(state, ref pixelParameters, ref pixelTextures);
        }

        public ModelRenderProxy(RenderCreateState state, MeshProxyEntity owner)
            : this(state, owner, owner.Mesh.MeshData)
        {
        }

        public ModelRenderProxy(RenderCreateState state, StaticModelEntity owner)
            : this(state, owner, owner.Mesh.MeshData)
        {
        }

#if false
        public ModelRenderProxy(RenderCreateState state, BangerEntity owner)
            : this(state, owner, owner.Mesh.MeshData)
        {
        }
#endif

        public ModelRenderProxy(RenderCreateState state, ClothEntity owner)
            : this(state, owner, owner.Mesh.MeshData)
        {
        }

        public ModelRenderProxy(RenderCreateState state, VegetationTreeEntity owner)
            : this(state, owner, owner.Mesh.MeshData)
        {
        }

        public override void Render(D3D11.DeviceContext context, MeshRenderPath renderPath)
        {
            if (renderPath == MeshRenderPath.Deferred)
            {
                permutation.SetState(context, renderPath);
                context.PixelShader.SetShaderResources(1, pixelTextures.ToArray());
                context.PixelShader.SetConstantBuffer(2, pixelParameters);

                renderData.GetLod(lodIndex).Render(context, renderPath);
            }
        }

        public override bool ShouldRender(float distToCamera, float screenSize)
        {
            return OwnerEntity.IsVisible && screenSize > renderData.CullScreenArea;
        }

        public override MeshRenderInstance GetInstance(float distToCamera)
        {
            lodIndex = 0;
            for (lodIndex = 0; lodIndex < 5; lodIndex++)
            {
                if (distToCamera < renderData.LodDistances[lodIndex])
                {
                    break;
                }
            }

            return new MeshRenderInstance() { RenderMesh = this, Transform = Transform };
        }

        public override void RecalculateBoundingBox()
        {
            OrientedBoundingBox meshBbox = new OrientedBoundingBox(renderData.Bounds);
            meshBbox.Transform(Transform);

            BoundingBox = meshBbox.GetBoundingBox();
        }

        public override void Dispose()
        {
            renderData.Dispose();
            permutation.Dispose();
            pixelParameters.Dispose();
            pixelTextures.Clear();
        }
    }
}
