using Frosty.Core;
using FrostySdk;
using FrostySdk.IO;
using FrostySdk.Managers;
using FrostySdk.Resources;
using LevelEditorPlugin.Editors;
using LevelEditorPlugin.Resources.Hkx;
using SharpDX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LevelEditorPlugin.Resources
{
    namespace Hkx
    {
        public class hkBaseClass
        {
            public long Offset;

            public virtual void Serialize(NativeReader reader, HkxHeader header)
            {
            }

            public virtual void Write(NativeWriter writer, HkxHeader header)
            {
            }
        }

        public class hkpStaticCompoundShape : hkBaseClass
        {
            public class hkpInstance
            {
                public Vector3 Translation { get; set; }
                public Vector4 Rotation { get; set; }
                public Vector3 Scale { get; set; }
                public uint FilterInfo { get; set; }
                public uint ChildFilterInfoMask { get; set; }
                public uint UserData { get; set; }

                public long DataOffset { get; set; }

                public void Serialize(NativeReader reader)
                {
                    DataOffset = reader.Position;
                    Translation = new Vector3(
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat()
                    );
                    reader.ReadFloat();

                    Rotation = new Vector4(
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat()
                    );

                    Scale = new Vector3(
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat()
                    );
                    reader.ReadFloat();

                    reader.ReadUInt();
                    FilterInfo = reader.ReadUInt();
                    ChildFilterInfoMask = reader.ReadUInt();
                    UserData = reader.ReadUInt();
                }
            }

            public class hkpTreeNode
            {
                public List<int> XYZ { get; set; }
                public int HiData { get; set; }
                public int LoData { get; set; }
            }

            public class hkpDomain
            {
                public Vector4 Min { get; set; }
                public Vector4 Max { get; set; }

                public void Serialize(NativeReader reader)
                {
                    Min = new Vector4(
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat()
                        );
                    Max = new Vector4(
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat()
                        );
                }
            }

            public class hkpTree
            {
                public List<hkpTreeNode> Nodes { get; set; }
                public hkpDomain Domain { get; set; }

                public void Serialize(NativeReader reader, bool is64bits = false)
                {
                    Nodes = new List<hkpTreeNode>();
                    Domain = new hkpDomain();

                    int NumTreeNodes = reader.ReadInt();
                    reader.BaseStream.Seek(is64bits ? 4 : 8, SeekOrigin.Current);

                    Domain.Serialize(reader);
                }
            }

            public byte DispatchType { get; set; }
            public byte BitsPerKey { get; set; }
            public byte ShapeInfoCodecType { get; set; }
            public uint UserData { get; set; }
            public byte BvTreeType { get; set; }
            public byte NumBitsForChildShapeKey { get; set; }
            public List<hkpInstance> Instances { get; set; }
            public hkpTree Tree { get; set; }

            public hkpStaticCompoundShape()
            {
            }

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                if (ProfilesLibrary.DataVersion == (int)ProfileVersion.PlantsVsZombiesGardenWarfare)
                {
                    if (header.Bits == 64)
                    {
                        reader.BaseStream.Seek(17, SeekOrigin.Current);
                        DispatchType = reader.ReadByte();
                        BitsPerKey = reader.ReadByte();
                        ShapeInfoCodecType = reader.ReadByte();
                        reader.BaseStream.Seek(4, SeekOrigin.Current);
                        UserData = reader.ReadUInt();
                        reader.BaseStream.Seek(4, SeekOrigin.Current);
                        BvTreeType = reader.ReadByte();
                        reader.BaseStream.Seek(15, SeekOrigin.Current);
                        NumBitsForChildShapeKey = reader.ReadByte();
                        reader.BaseStream.Seek(15, SeekOrigin.Current);
                        int NumInstances64 = reader.ReadInt();
                        reader.BaseStream.Seek(52, SeekOrigin.Current);

                        Tree = new hkpTree();
                        Tree.Serialize(reader, true);

                        reader.BaseStream.Seek(16, SeekOrigin.Current);
                        Instances = new List<hkpInstance>();

                        for (int i = 0; i < NumInstances64; i++)
                        {
                            hkpInstance CurInstance = new hkpInstance();
                            CurInstance.Serialize(reader);
                            reader.BaseStream.Seek(16, SeekOrigin.Current);
                            Instances.Add(CurInstance);
                        }
                        return;
                    }
                }

                reader.BaseStream.Seek(9, SeekOrigin.Current);
                DispatchType = reader.ReadByte();
                BitsPerKey = reader.ReadByte();
                ShapeInfoCodecType = reader.ReadByte();
                UserData = reader.ReadUInt();
                BvTreeType = reader.ReadByte();
                reader.BaseStream.Seek(7, SeekOrigin.Current);
                NumBitsForChildShapeKey = reader.ReadByte();
                reader.BaseStream.Seek(11, SeekOrigin.Current);
                int NumInstances = reader.ReadInt();
                reader.BaseStream.Seek(28, SeekOrigin.Current);

                Tree = new hkpTree();
                Tree.Serialize(reader);

                reader.BaseStream.Seek(16, SeekOrigin.Current);
                Instances = new List<hkpInstance>();

                for (int i = 0; i < NumInstances; i++)
                {
                    hkpInstance CurInstance = new hkpInstance();
                    CurInstance.Serialize(reader);

                    Instances.Add(CurInstance);
                }
            }
        }

        public class hknpShape : hkBaseClass
        {
            public ushort Flags;
            public byte NumShapeKeyBits;
            public byte DispatchType;
            public float ConvexRadius;
            public ulong UserData;
            public hkRefCountedProperties Properties;

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                reader.Position += 16;
                Flags = reader.ReadUShort();
                NumShapeKeyBits = reader.ReadByte();
                DispatchType = reader.ReadByte();
                ConvexRadius = reader.ReadFloat();
                UserData = reader.ReadULong();
                Properties = header.ReadObject(reader) as hkRefCountedProperties;
            }

            public override void Write(NativeWriter writer, HkxHeader header)
            {
                writer.Position += 16;
                writer.Write(Flags);
                writer.Write(NumShapeKeyBits);
                writer.Write(DispatchType);
                writer.Write(ConvexRadius);
                writer.Write(UserData);
                writer.Position += header.Bits == 64 ? 8 : 4;
            }
        }

        public class hknpCompositeShape : hknpShape
        {
            public uint SecondaryKeyMask;
            public uint SecondaryKeyBits;
            public List<ushort> PrimaryKeyToIndex = new List<ushort>();
            public List<ushort> ValueAndSecondaryKeys = new List<ushort>();
            public uint ShapeTagCodecInfo;

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                base.Serialize(reader, header);

                reader.Position += 8;

                SecondaryKeyMask = reader.ReadUInt();
                SecondaryKeyBits = reader.ReadUInt();

                long offsetPrimaryKeyToIndex = header.ReadArray(reader, out int numPrimaryKeyToIndex);
                long offsetValueAndSecondaryKeys = header.ReadArray(reader, out int numValueAndSecondaryKeys);

                ShapeTagCodecInfo = reader.ReadUInt();

                long position = reader.Position;

                if (offsetPrimaryKeyToIndex != -1)
                {
                    reader.Position = offsetPrimaryKeyToIndex;
                    for (int i = 0; i < numPrimaryKeyToIndex; i++)
                    {
                        PrimaryKeyToIndex.Add(reader.ReadUShort());
                    }
                }

                if (offsetValueAndSecondaryKeys != -1)
                {
                    reader.Position = offsetValueAndSecondaryKeys;
                    for (int i = 0; i < numValueAndSecondaryKeys; i++)
                    {
                        ValueAndSecondaryKeys.Add(reader.ReadUShort());
                    }
                }

                reader.Position = position;
                reader.Position += 4;
            }

            public override void Write(NativeWriter writer, HkxHeader header)
            {
                base.Write(writer, header);

                writer.Write(SecondaryKeyMask);
                writer.Write(SecondaryKeyBits);

                long position = writer.Position;

                header.WriteArray(writer, PrimaryKeyToIndex.Count, w =>
                {
                    foreach (ushort value in PrimaryKeyToIndex)
                    {
                        w.Write(value);
                    }
                });

                header.WriteArray(writer, ValueAndSecondaryKeys.Count, w =>
                {
                    foreach (ushort value in ValueAndSecondaryKeys)
                    {
                        w.Write(value);
                    }
                });

                writer.Write(ShapeTagCodecInfo);
                writer.Position += 4;
            }
        }

        public class hknpCapsuleShape : hknpShape
        {
        }

        public class PolytopeShape
        {
            public List<Vector4> Vertices { get; set; } = new List<Vector4>();
            public List<Vector4> Planes { get; set; } = new List<Vector4>();
            public List<PolytopeShapeFace> Faces { get; set; } = new List<PolytopeShapeFace>();
            public List<byte> Indices { get; set; } = new List<byte>();
        }

        public class PolytopeShapeFace
        {
            public byte MinHalfAngle { get; set; }
            public byte NumIndices { get; set; }
            public ushort FirstIndex { get; set; }
        }

        public class hknpConvexPolytopeShape : hknpShape
        {
            public List<Vector4> Vertices = new List<Vector4>();
            public List<Vector4> Planes = new List<Vector4>();
            public List<byte[]> Faces = new List<byte[]>();
            public List<byte> Indices = new List<byte>();

            public long VerticesHeaderOffset;
            public long PlanesHeaderOffset;
            public long FacesHeaderOffset;
            public long IndicesHeaderOffset;

            public long VerticesDataOffset;
            public long PlanesDataOffset;
            public long FacesDataOffset;
            public long IndicesDataOffset;

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                base.Serialize(reader, header);
                reader.Position += 0x08;

                VerticesHeaderOffset = reader.Position;
                int numVertices = header.BeginRelArrayRead(reader);
                VerticesDataOffset = reader.Position;
                for (int i = 0; i < numVertices; i++)
                {
                    Vertices.Add(new Vector4(
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat()
                        ));
                }
                header.EndRelArrayRead(reader);

                reader.Position += 0x0c;

                PlanesHeaderOffset = reader.Position;
                int numPlanes = header.BeginRelArrayRead(reader);
                PlanesDataOffset = reader.Position;
                for (int i = 0; i < numPlanes; i++)
                {
                    Planes.Add(new Vector4(
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat(),
                        reader.ReadFloat()
                        ));
                }
                header.EndRelArrayRead(reader);

                FacesHeaderOffset = reader.Position;
                int numFaces = header.BeginRelArrayRead(reader);
                FacesDataOffset = reader.Position;
                for (int i = 0; i < numFaces; i++)
                {
                    Faces.Add(new byte[]
                    {
                        reader.ReadByte(),
                        reader.ReadByte(),
                        reader.ReadByte(),
                        reader.ReadByte()
                    });
                }
                header.EndRelArrayRead(reader);

                IndicesHeaderOffset = reader.Position;
                int numIndices = header.BeginRelArrayRead(reader);
                IndicesDataOffset = reader.Position;
                for (int i = 0; i < numIndices; i++)
                {
                    Indices.Add(reader.ReadByte());
                }
                header.EndRelArrayRead(reader);
            }

            public PolytopeShape GetPolytopeShape()
            {
                PolytopeShape shape = new PolytopeShape();
                shape.Vertices.AddRange(Vertices);
                shape.Planes.AddRange(Planes);
                foreach (byte[] face in Faces)
                {
                    shape.Faces.Add(new PolytopeShapeFace
                    {
                        MinHalfAngle = face[0],
                        NumIndices = face[1],
                        FirstIndex = BitConverter.ToUInt16(face, 2)
                    });
                }
                shape.Indices.AddRange(Indices);
                return shape;
            }

            public void Write(NativeWriter writer, PolytopeShape shape)
            {
                writer.Position = VerticesHeaderOffset;
                writer.Write((ushort)shape.Vertices.Count);
                writer.Position = VerticesDataOffset;
                for (int i = 0; i < shape.Vertices.Count; i++)
                {
                    writer.Write(shape.Vertices[i].X);
                    writer.Write(shape.Vertices[i].Y);
                    writer.Write(shape.Vertices[i].Z);
                    writer.Write(shape.Vertices[i].W);
                }

                writer.Position = PlanesHeaderOffset;
                writer.Write((ushort)shape.Planes.Count);
                writer.Position = PlanesDataOffset;
                for (int i = 0; i < shape.Planes.Count; i++)
                {
                    writer.Write(shape.Planes[i].X);
                    writer.Write(shape.Planes[i].Y);
                    writer.Write(shape.Planes[i].Z);
                    writer.Write(shape.Planes[i].W);
                }

                writer.Position = FacesHeaderOffset;
                writer.Write((ushort)shape.Faces.Count);
                writer.Position = FacesDataOffset;
                for (int i = 0; i < shape.Faces.Count; i++)
                {
                    writer.Write(shape.Faces[i].MinHalfAngle);
                    writer.Write(shape.Faces[i].NumIndices);
                    writer.Write(shape.Faces[i].FirstIndex);
                }

                writer.Position = IndicesHeaderOffset;
                writer.Write((ushort)shape.Indices.Count);
                writer.Position = IndicesDataOffset;
                for (int i = 0; i < shape.Indices.Count; i++)
                {
                    writer.Write(shape.Indices[i]);
                }
            }

            public bool IsShapeValid(PolytopeShape shape)
            {
                if (shape == null || shape.Vertices == null || shape.Planes == null || shape.Faces == null || shape.Indices == null)
                    return false;

                foreach (var face in shape.Faces)
                {
                    if (face == null)
                        return false;
                }

                return true;
            }

            public bool ShapeFits(PolytopeShape shape)
            {
                if (shape.Vertices.Count > Vertices.Count ||
                    shape.Planes.Count > Planes.Count ||
                    shape.Faces.Count > Faces.Count ||
                    shape.Indices.Count > Indices.Count)
                {
                    return false;
                }

                return true;
            }
        }
        public class hknpSphereShape : hknpShape
        {
        }

        public class TreeNode
        {
            public byte[] XYZ = new byte[3];
            public byte Data;
        }

        public class hkcdStaticMeshTreeBaseSection : hkBaseClass
        {
            public List<TreeNode> Nodes = new List<TreeNode>();
            public Vector4 MinAABB;
            public Vector4 MaxAABB;
            public float[] CodecParams = new float[6];
            public uint FirstPackedVertex;
            public uint SharedVertices;
            public uint Primitives;
            public uint DataRuns;
            public byte NumPackedVertices;
            public byte NumSharedIndicies;
            public ushort LeafIndex;
            public byte Page;
            public byte Flags;
            public byte LayerData;
            public byte UnusedData;

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                long offsetNodes = header.ReadArray(reader, out int numNodes);
                MinAABB = reader.ReadVector4();
                MaxAABB = reader.ReadVector4();
                for (int i = 0; i < 6; i++)
                {
                    CodecParams[i] = reader.ReadFloat();
                }
                FirstPackedVertex = reader.ReadUInt();
                SharedVertices = reader.ReadUInt();
                Primitives = reader.ReadUInt();
                DataRuns = reader.ReadUInt();
                NumPackedVertices = reader.ReadByte();
                NumSharedIndicies = reader.ReadByte();
                LeafIndex = reader.ReadUShort();
                Page = reader.ReadByte();
                Flags = reader.ReadByte();
                LayerData = reader.ReadByte();
                UnusedData = reader.ReadByte();

                if (numNodes != -1)
                {
                    long position = reader.Position;
                    reader.Position = offsetNodes;
                    for (int i = 0; i < numNodes; i++)
                    {
                        var node = new TreeNode();
                        node.XYZ = reader.ReadBytes(3);
                        node.Data = reader.ReadByte();
                        Nodes.Add(node);
                    }

                    reader.Position = position;
                }
            }

            public override void Write(NativeWriter writer, HkxHeader header)
            {
                header.WriteArray(writer, Nodes.Count, w =>
                {
                    foreach (var value in Nodes)
                    {
                        w.Write(value.XYZ);
                        w.Write(value.Data);
                    }
                });

                writer.Write(MinAABB);
                writer.Write(MaxAABB);
                foreach (float value in CodecParams)
                {
                    writer.Write(value);
                }
                writer.Write(FirstPackedVertex);
                writer.Write(SharedVertices);
                writer.Write(Primitives);
                writer.Write(DataRuns);
                writer.Write(NumPackedVertices);
                writer.Write(NumSharedIndicies);
                writer.Write(LeafIndex);
                writer.Write(Page);
                writer.Write(Flags);
                writer.Write(LayerData);
                writer.Write(UnusedData);
            }
        }

        public class hknpCompressedMeshShapeTreeDataRun : hkBaseClass
        {
            public ushort Value;
            public byte Index;
            public byte Count;

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                Value = reader.ReadUShort();
                Index = reader.ReadByte();
                Count = reader.ReadByte();
            }

            public override void Write(NativeWriter writer, HkxHeader header)
            {
                writer.Write(Value);
                writer.Write(Index);
                writer.Write(Count);
            }
        }

        public class hknpCompressedMeshShapeData : hkBaseClass
        {
            public List<TreeNode> Nodes = new List<TreeNode>();
            public Vector4 MinAABB;
            public Vector4 MaxAABB;
            public int NumPrimitiveKeys;
            public int BitsPerKey;
            public uint MaxKeyValue;
            public List<hkcdStaticMeshTreeBaseSection> Sections = new List<hkcdStaticMeshTreeBaseSection>();
            public List<byte[]> Primitives = new List<byte[]>();
            public List<ushort> SharedVerticesIndex = new List<ushort>();
            public List<uint> PackedVertices = new List<uint>();
            public List<ulong> SharedVertices = new List<ulong>();
            public List<hknpCompressedMeshShapeTreeDataRun> PrimitiveDataRuns = new List<hknpCompressedMeshShapeTreeDataRun>();

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                reader.Position += 16;

                long offsetNodes = header.ReadArray(reader, out int numNodes);
                MinAABB = reader.ReadVector4();
                MaxAABB = reader.ReadVector4();
                NumPrimitiveKeys = reader.ReadInt();
                BitsPerKey = reader.ReadInt();
                MaxKeyValue = reader.ReadUInt();

                reader.Position += 4;

                long offsetSections = header.ReadArray(reader, out int numSections);
                long offsetPrimitives = header.ReadArray(reader, out int numPrimitives);
                long offsetSharedVerticesIndex = header.ReadArray(reader, out int numSharedVerticesIndex);
                long offsetPackedVertices = header.ReadArray(reader, out int numPackedVertices);
                long offsetSharedVertices = header.ReadArray(reader, out int numSharedVertices);
                long offsetPrimitiveDataRuns = header.ReadArray(reader, out int numPrimitiveDataRuns);

                if (numNodes != -1)
                {
                    reader.Position = offsetNodes;
                    for (int i = 0; i < numNodes; i++)
                    {
                        var node = new TreeNode();
                        node.XYZ = reader.ReadBytes(3);
                        node.Data = reader.ReadByte();
                        Nodes.Add(node);
                    }
                }

                if (offsetSections != -1)
                {
                    reader.Position = offsetSections;
                    for (int i = 0; i < numSections; i++)
                    {
                        var obj = new hkcdStaticMeshTreeBaseSection();
                        obj.Serialize(reader, header);
                        Sections.Add(obj);
                    }
                }

                if (offsetPrimitives != -1)
                {
                    reader.Position = offsetPrimitives;
                    for (int i = 0; i < numPrimitives; i++)
                    {
                        Primitives.Add(reader.ReadBytes(4));
                    }
                }

                if (offsetSharedVerticesIndex != -1)
                {
                    reader.Position = offsetSharedVerticesIndex;
                    for (int i = 0; i < numSharedVerticesIndex; i++)
                    {
                        SharedVerticesIndex.Add(reader.ReadUShort());
                    }
                }

                if (offsetPackedVertices != -1)
                {
                    reader.Position = offsetPackedVertices;
                    for (int i = 0; i < numPackedVertices; i++)
                    {
                        PackedVertices.Add(reader.ReadUInt());
                    }
                }

                if (offsetSharedVertices != -1)
                {
                    reader.Position = offsetSharedVertices;
                    for (int i = 0; i < numSharedVertices; i++)
                    {
                        SharedVertices.Add(reader.ReadULong());
                    }
                }

                if (offsetPrimitiveDataRuns != -1)
                {
                    reader.Position = offsetPrimitiveDataRuns;
                    for (int i = 0; i < numPrimitiveDataRuns; i++)
                    {
                        var obj = new hknpCompressedMeshShapeTreeDataRun();
                        obj.Serialize(reader, header);
                        PrimitiveDataRuns.Add(obj);
                    }
                }
            }

            public override void Write(NativeWriter writer, HkxHeader header)
            {
                writer.Position += 16;

                header.WriteArray(writer, Nodes.Count, w =>
                {
                    foreach (var value in Nodes)
                    {
                        w.Write(value.XYZ);
                        w.Write(value.Data);
                    }
                });

                writer.Write(MinAABB);
                writer.Write(MaxAABB);
                writer.Write(NumPrimitiveKeys);
                writer.Write(BitsPerKey);
                writer.Write(MaxKeyValue);

                writer.Position += 4;

                header.WriteArray(writer, Sections.Count, w =>
                {
                    foreach (var value in Sections)
                    {
                        value.Write(w, header);
                    }
                });
                header.WriteArray(writer, Primitives.Count, w =>
                {
                    foreach (byte[] value in Primitives)
                    {
                        w.Write(value);
                    }
                });
                header.WriteArray(writer, SharedVerticesIndex.Count, w =>
                {
                    foreach (ushort value in SharedVerticesIndex)
                    {
                        w.Write(value);
                    }
                });
                header.WriteArray(writer, PackedVertices.Count, w =>
                {
                    foreach (uint value in PackedVertices)
                    {
                        w.Write(value);
                    }
                });
                header.WriteArray(writer, SharedVertices.Count, w =>
                {
                    foreach (ulong value in SharedVertices)
                    {
                        w.Write(value);
                    }
                });
                header.WriteArray(writer, PrimitiveDataRuns.Count, w =>
                {
                    foreach (var value in PrimitiveDataRuns)
                    {
                        value.Write(w, header);
                    }
                });
            }
        }
        public class hknpCompressedMeshShape : hknpCompositeShape
        {
            public hknpCompressedMeshShapeData Data;

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                base.Serialize(reader, header);
                Data = header.ReadObject(reader) as hknpCompressedMeshShapeData;
            }

            // no write method because Data already points to the object
        }

        public class hknpStaticCompoundShape : hknpShape
        {
            public class hknpInstance
            {
                public Matrix Transform;
                public Matrix Rotation;
                public Vector3 Translation;
                public Vector3 Scale;
                public float Test;
                public hkBaseClass shape;
                //public ushort shapeTag;
                //public ushort destructionTag;
                public uint[] unknowns = new uint[10];
                public long DataOffset { get; set; }

                public uint tmp1;
                public uint tmp2;
                public uint tmp3;
                public uint tmp4;
                public uint tmp5;

                public void Serialize(NativeReader reader, HkxHeader header)
                {
                    DataOffset = reader.Position;

                    Matrix m = new Matrix();
                    m.M11 = reader.ReadFloat(); m.M12 = reader.ReadFloat(); m.M13 = reader.ReadFloat(); tmp1 = reader.ReadUInt();
                    m.M21 = reader.ReadFloat(); m.M22 = reader.ReadFloat(); m.M23 = reader.ReadFloat(); tmp2 = reader.ReadUInt();
                    m.M31 = reader.ReadFloat(); m.M32 = reader.ReadFloat(); m.M33 = reader.ReadFloat(); tmp3 = reader.ReadUInt();
                    m.M41 = reader.ReadFloat(); m.M42 = reader.ReadFloat(); m.M43 = reader.ReadFloat(); tmp4 = reader.ReadUInt();
                    Transform = m;
                    Rotation = m;//Quaternion.RotationMatrix(m);

                    //Translation = new Vector3(reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat());
                    //tmp4 = reader.ReadFloat();

                    Scale = new Vector3(reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat());
                    tmp5 = reader.ReadUInt();

                    shape = header.ReadObject(reader);
                    //shapeTag = reader.ReadUShort();
                    //destructionTag = reader.ReadUShort();

                    for (int i = 0; i < 10; i++)
                        unknowns[i] = reader.ReadUInt();
                }
            }

            public List<hknpInstance> Instances = new List<hknpInstance>();
            public Vector4 Unknown1;
            public Vector4 Unknown2;
            public hknpStaticCompoundShapeData ShapeData;

            public hknpStaticCompoundShape()
            {
            }

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                base.Serialize(reader, header);

                reader.Position += 0x38;
                long arrayOffset = header.ReadArray(reader);
                int numInstances = reader.ReadInt();

                reader.Position += 0x14;
                Unknown1 = new Vector4(
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat()
                    );
                Unknown2 = new Vector4(
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat()
                    );

                reader.Position += 0x20;
                ShapeData = header.ReadObject(reader) as hknpStaticCompoundShapeData;

                if (arrayOffset != -1)
                {
                    reader.Position = arrayOffset;
                    for (int i = 0; i < numInstances; i++)
                    {
                        hknpInstance inst = new hknpInstance();
                        inst.Serialize(reader, header);

                        Instances.Add(inst);
                    }
                }
            }
        }

        public class hknpStaticCompoundShapeData : hkBaseClass
        {
            public class TreeNode
            {
                public ushort Index;
                public byte X;
                public byte Y;
                public byte Z;

                public bool HasChildren;
                public List<TreeNode> Children = new List<TreeNode>();

                public TreeNode(byte[] data)
                {
                    X = data[0];
                    Y = data[1];
                    Z = data[2];
                    HasChildren = data[3] != 0;
                    Index = BitConverter.ToUInt16(data, 4);
                }
            }

            public Vector4 Unknown1;
            public Vector4 Unknown2;
            public List<byte[]> Unknowns = new List<byte[]>();
            public long ArrayOffset;
            public TreeNode RootNode;

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                base.Serialize(reader, header);
                reader.Position += 0x10;

                ArrayOffset = header.ReadArray(reader);
                int numItems = reader.ReadInt();
                reader.Position += 4;

                Unknown1 = new Vector4(
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat()
                    );
                Unknown2 = new Vector4(
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat()
                    );

                if (ArrayOffset != -1)
                {
                    reader.Position = ArrayOffset;
                    for (int i = 0; i < numItems; i++)
                    {
                        Unknowns.Add(reader.ReadBytes(6));
                    }
                }
            }
        }

        public class hkRefCountedProperties : hkBaseClass
        {
            public List<hkBaseClass> Properties = new List<hkBaseClass>();

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                base.Serialize(reader, header);

                long arrayOffset = header.ReadArray(reader);
                int numItems = reader.ReadInt();

                if (arrayOffset != -1)
                {
                    reader.Position = arrayOffset;
                    for (int i = 0; i < numItems; i++)
                    {
                        Properties.Add(header.ReadObject(reader));
                    }
                }
            }
        }

        public class hknpShapeMassProperties : hkBaseClass
        {
            public Vector4 Unknown1;
            public Vector4 Unknown2;

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                base.Serialize(reader, header);
                reader.Position += 0x10;

                Unknown1 = new Vector4(
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat()
                    );
                Unknown2 = new Vector4(
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat(),
                    reader.ReadFloat()
                    );
            }
        }

        public class HavokPhysicsContainer : hkBaseClass
        {
            public List<hkBaseClass> Objects = new List<hkBaseClass>();

            public override void Serialize(NativeReader reader, HkxHeader header)
            {
                base.Serialize(reader, header);
                reader.Position += 0x10;

                long arrayOffset = header.ReadArray(reader);
                int numItems = reader.ReadInt();

                if (arrayOffset != -1)
                {
                    reader.Position = arrayOffset;
                    for (int i = 0; i < numItems; i++)
                    {
                        Objects.Add(header.ReadObject(reader));
                    }
                }
            }
        }

        //public class hkRootLevelContainer : hkBaseClass
        //{
        //}
    }

    public static partial class ReaderUtils
    {

    }

    public class HkxHeader
    {
        public struct ArrayData
        {
            public long Offset;
            public int Count;
            public Action<NativeWriter> Write;
        }

        public uint StartOffset;
        public uint Magic1;
        public uint Magic2;
        public uint UserTag;
        public uint FileVersion;
        public uint LayoutRules;
        public uint NumSections;
        public uint ContentsSectionIndex;
        public uint ContentsSectionOffset;
        public uint ContentsClassNameSectionIndex;
        public uint ContentsClassNameSectionOffset;
        public String ContentsVersion;
        public uint Flags;
        public uint Padding;
        public int Bits;

        public Dictionary<long, long> ArrayOffsets = new Dictionary<long, long>();
        public Dictionary<long, Hkx.hkBaseClass> ObjectOffsets = new Dictionary<long, Hkx.hkBaseClass>();

        public List<ArrayData> ModifiedArrays = new List<ArrayData>();

        private List<long> stackOffsets = new List<long>();

        public bool IsValid() { return (Magic1 == 0x57e0e057 && Magic2 == 0x10c0c010); }

        public void Serialize(NativeReader reader, int bits)
        {
            Bits = bits;
            Magic1 = reader.ReadUInt();
            if (Magic1 != 0x57e0e057)
            {
                do
                {
                    reader.BaseStream.Seek(-3, SeekOrigin.Current);
                    Magic1 = reader.ReadUInt();
                }
                while (Magic1 != 0x57e0e057);
            }

            StartOffset = (uint)reader.BaseStream.Position - 4;
            Magic2 = reader.ReadUInt();
            if (Magic2 == 0x10c0c010)
            {
                UserTag = reader.ReadUInt();
                FileVersion = reader.ReadUInt();
                LayoutRules = reader.ReadUInt();
                NumSections = reader.ReadUInt();
                ContentsSectionIndex = reader.ReadUInt();
                ContentsSectionOffset = reader.ReadUInt();
                ContentsClassNameSectionIndex = reader.ReadUInt();
                ContentsClassNameSectionOffset = reader.ReadUInt();
                ContentsVersion = reader.ReadTerminatedString(0xff);
                Flags = reader.ReadUInt();
                Padding = reader.ReadUInt();
            }
        }

        public Hkx.hkBaseClass ReadObject(NativeReader reader)
        {
            reader.ReadInt();
            if (Bits == 64)
                reader.ReadInt();

            if (!ObjectOffsets.ContainsKey(reader.Position - (Bits == 64 ? 8 : 4)))
                return null;
            return ObjectOffsets[reader.Position - (Bits == 64 ? 8 : 4)];
        }

        public long ReadArray(NativeReader reader)
        {
            long key = reader.Position;
            reader.ReadInt();
            if (Bits == 64)
                reader.ReadInt();

            if (!ArrayOffsets.ContainsKey(key))
                return -1;

            return ArrayOffsets[key];
        }

        public long ReadArray(NativeReader reader, out int count)
        {
            long offset = ReadArray(reader);
            count = reader.ReadInt();
            reader.ReadInt();
            return offset;
        }

        public void WriteArray(NativeWriter writer, int count, Action<NativeWriter> write)
        {
            long key = writer.Position;
            writer.Position += Bits == 64 ? 8 : 4;

            writer.Write(count);
            writer.Position += 4;

            if (ArrayOffsets.ContainsKey(key))
            {
                ModifiedArrays.Add(new ArrayData
                {
                    Offset = key,
                    Count = count,
                    Write = write
                });
            }
        }

        public int BeginRelArrayRead(NativeReader reader)
        {
            ushort numEntries = reader.ReadUShort();
            ushort offset = reader.ReadUShort();

            stackOffsets.Add(reader.Position);
            reader.Position += (offset - 4);

            return numEntries;
        }

        public void EndRelArrayRead(NativeReader reader)
        {
            reader.Position = stackOffsets[stackOffsets.Count - 1];
            stackOffsets.RemoveAt(stackOffsets.Count - 1);
        }
    }

    public class HkxInstance
    {
        public class HkxClassDescriptor
        {
            public uint Signature;
            public byte Version;
            public String Name;

            public HkxClassDescriptor()
            {
            }

            public void Serialize(NativeReader reader)
            {
                Signature = reader.ReadUInt();
                Version = reader.ReadByte();
                Name = reader.ReadNullTerminatedString();
            }
        }

        public HkxHeader Header { get; set; }
        public List<Hkx.hkBaseClass> Objects => objList.Values.ToList();

        public int LocalFixupSize;
        public int GlobalFixupSize;
        public int AbsoluteDataStart;
        public int SectionIntsPos;

        public int VirtualFixupsOffset;
        public int exportsOffset;
        public int importsOffset;
        public int endOffset;

        Dictionary<ulong, HkxClassDescriptor> Classes = new Dictionary<ulong, HkxClassDescriptor>();
        Dictionary<long, Hkx.hkBaseClass> objList = new Dictionary<long, Hkx.hkBaseClass>();

        public void Serialize(NativeReader reader, int bits)
        {
            Header = new HkxHeader();
            Header.Serialize(reader, bits);

            int ClassSectionOffset = 0;
            int ClassSectionSize = 0;
            int TypesSectionOffset = 0;
            int CurrentSection = 0;

            while (CurrentSection < Header.NumSections)
            {
                String BlockType = reader.ReadTerminatedString(0xff);
                if (BlockType.Contains("__classnames__"))
                {
                    ClassSectionOffset = reader.ReadInt();
                    reader.ReadLong();
                    ClassSectionSize = reader.ReadInt();
                    reader.BaseStream.Seek(12, SeekOrigin.Current);
                    CurrentSection++;
                }
                else if (BlockType.Contains("__types__"))
                {
                    TypesSectionOffset = reader.ReadInt();
                    reader.BaseStream.Seek(24, SeekOrigin.Current);
                    CurrentSection++;
                }
                else if (BlockType.Contains("__data__"))
                {
                    SectionIntsPos = (int)reader.Position;
                    AbsoluteDataStart = reader.ReadInt();
                    LocalFixupSize = reader.ReadInt();
                    GlobalFixupSize = reader.ReadInt();
                    VirtualFixupsOffset = reader.ReadInt();
                    exportsOffset = reader.ReadInt();
                    importsOffset = reader.ReadInt();
                    endOffset = reader.ReadInt();
                    CurrentSection++;
                }
            }

            reader.Position = Header.StartOffset + ClassSectionOffset;
            while (reader.BaseStream.Position < (Header.StartOffset + ClassSectionOffset + ClassSectionSize))
            {
                ulong ClassOffset = (ulong)(reader.BaseStream.Position - (Header.StartOffset + ClassSectionOffset));
                HkxClassDescriptor Class = new HkxClassDescriptor();
                Class.Serialize(reader);

                Classes.Add(ClassOffset + 5, Class);
            }

            reader.Position = Header.StartOffset + AbsoluteDataStart + VirtualFixupsOffset;

            int TotalSize = (int)Header.StartOffset + AbsoluteDataStart + endOffset;

            while (reader.BaseStream.Position < TotalSize)
            {
                long DataOffset = reader.ReadLong();
                int ClassType = reader.ReadInt();

                if (ClassType != -1 && reader.BaseStream.Position < TotalSize)
                {
                    HkxClassDescriptor CurrentClassDescriptor = Classes[(ulong)ClassType];
                    Type type = Type.GetType("LevelEditorPlugin.Resources.Hkx." + CurrentClassDescriptor.Name);

                    if (type != null)
                    {
                        Hkx.hkBaseClass BaseClass = (Hkx.hkBaseClass)Activator.CreateInstance(type);
                        BaseClass.Offset = Header.StartOffset + AbsoluteDataStart + DataOffset;
                        objList.Add(BaseClass.Offset, BaseClass);
                    }
                }
            }

            reader.Position = Header.StartOffset + AbsoluteDataStart + endOffset;
        }

        public void ReadObjects(NativeReader reader)
        {
            foreach (long offset in objList.Keys)
            {
                Hkx.hkBaseClass value = objList[offset];
                if (value != null)
                {
                    reader.Position = offset;
                    value.Serialize(reader, Header);
                }
            }
        }

        public void WriteObjects(NativeWriter writer)
        {
            foreach (long offset in objList.Keys)
            {
                Hkx.hkBaseClass value = objList[offset];
                if (value != null)
                {
                    writer.Position = offset;
                    value.Write(writer, Header);
                }
            }
        }

        public Hkx.hkBaseClass GetObject(long offset)
        {
            if (!objList.ContainsKey(offset))
                return null;
            return objList[offset];
        }
    }

    public class HavokPhysicsData : Resource
    {
        public HkxInstance Inst32 => inst32;
        public HkxInstance Inst64 => inst64;

        Hkx.hknpStaticCompoundShape RootShape => (inst64.Objects[0] as Hkx.HavokPhysicsContainer).Objects[0] as Hkx.hknpStaticCompoundShape;

        private int partCount;
        private List<Vec3> partTranslations = new List<Vec3>();
        private List<AxisAlignedBox> localAabbs = new List<AxisAlignedBox>();
        private List<byte> materialIndices = new List<byte>();
        private List<uint> materialFlagsAndIndices = new List<uint>();
        private List<ushort> unknownIndices = new List<ushort>();
        private byte materialCountUsed;
        private byte highestMaterialIndex;

        private long fixupSizesPos;
        private long fixupTable64Pos;
        private int originalFixupSize64;

        // from resMeta
        private ushort packFilesOffset;
        private uint firstPackFileSize;
        private uint secondPackFileSize;
        private uint fixupTablesSize;

        private Dictionary<int, Matrix> modifiedTransforms = new Dictionary<int, Matrix>();

        private HkxInstance inst32;
        private HkxInstance inst64;

        private byte[] resData;
        private ResAssetEntry resEntry;

        public Hkx.PolytopeShape Collision { get; set; }

        public override void Read(NativeReader reader, AssetManager am, ResAssetEntry entry, ModifiedResource inModifiedData)
        {
            base.Read(reader, am, entry, inModifiedData);

            resData = reader.ReadToEnd();
            resEntry = entry;

            packFilesOffset = BitConverter.ToUInt16(resMeta, 0x00);
            firstPackFileSize = BitConverter.ToUInt32(resMeta, 0x04);
            secondPackFileSize = BitConverter.ToUInt32(resMeta, 0x08);
            fixupTablesSize = BitConverter.ToUInt32(resMeta, 0x0C);

            reader.Position = 0;

            {
                partCount = reader.ReadInt();

                int partTranslationsCount = reader.ReadInt();
                reader.ReadLong();
                int localAabbsCount = reader.ReadInt();
                reader.ReadLong();
                int materialIndicesCount = reader.ReadInt();
                reader.ReadLong();
                int materialFlagsAndIndicesCount = reader.ReadInt();
                reader.ReadLong();

                int unknownCount = 0;
                if (ProfilesLibrary.DataVersion != 20141118 && ProfilesLibrary.DataVersion != 20141117 && ProfilesLibrary.DataVersion != 20140225)
                {
                    unknownCount = reader.ReadInt();
                    reader.ReadLong();
                }

                materialCountUsed = reader.ReadByte();
                highestMaterialIndex = reader.ReadByte();
                reader.ReadBytes(2);
                reader.Pad(16);

                for (int i = 0; i < partTranslationsCount; i++)
                    partTranslations.Add(reader.ReadVec3());
                reader.Pad(16);
                for (int i = 0; i < localAabbsCount; i++)
                    localAabbs.Add(reader.ReadAxisAlignedBox());
                reader.Pad(16);
                for (int i = 0; i < materialIndicesCount; i++)
                    materialIndices.Add(reader.ReadByte());
                reader.Pad(16);
                for (int i = 0; i < materialFlagsAndIndicesCount; i++)
                    materialFlagsAndIndices.Add(reader.ReadUInt());
                reader.Pad(16);

                if (ProfilesLibrary.DataVersion != 20141118 && ProfilesLibrary.DataVersion != 20141117)
                {
                    for (int i = 0; i < unknownCount; i++)
                        unknownIndices.Add(reader.ReadUShort());
                    reader.Pad(16);
                }
            }

            inst32 = new HkxInstance();
            inst32.Serialize(reader, 32);

            inst64 = new HkxInstance();
            inst64.Serialize(reader, 64);

            fixupSizesPos = reader.Position;
            int fixupSize32 = reader.ReadInt();
            int fixupSize64 = reader.ReadInt();
            originalFixupSize64 = fixupSize64;

            long pos = reader.Position;
            long fileOffset = inst32.Header.StartOffset + inst32.AbsoluteDataStart;

            while (reader.Position < (pos + inst32.GlobalFixupSize))
            {
                int offset = reader.ReadInt();
                int objOffset = reader.ReadInt();

                if (offset != -1)
                    inst32.Header.ArrayOffsets.Add(fileOffset + offset, fileOffset + objOffset);
            }
            while (reader.Position < (pos + inst32.LocalFixupSize - inst32.GlobalFixupSize))
            {
                int offset = reader.ReadInt();
                int unknown = reader.ReadInt();
                int objOffset = reader.ReadInt();

                inst32.Header.ObjectOffsets.Add(fileOffset + offset, inst32.GetObject(fileOffset + objOffset));
            }

            reader.Position = (pos + fixupSize32);
            pos = reader.Position;
            fixupTable64Pos = pos;

            fileOffset = inst64.Header.StartOffset + inst64.AbsoluteDataStart;

            while (reader.Position < (pos + inst64.GlobalFixupSize))
            {
                int offset = reader.ReadInt();
                int objOffset = reader.ReadInt();

                if (offset != -1)
                    inst64.Header.ArrayOffsets.Add(fileOffset + offset, fileOffset + objOffset);
            }
            pos = reader.Position;
            while (reader.Position < (pos + (inst64.LocalFixupSize - inst64.GlobalFixupSize)))
            {
                int offset = reader.ReadInt();
                int unknown = reader.ReadInt();
                int objOffset = reader.ReadInt();

                inst64.Header.ObjectOffsets.Add(fileOffset + offset, inst64.GetObject(fileOffset + objOffset));
            }

            //inst32.ReadObjects(reader);
            inst64.ReadObjects(reader);
        }

        public void UpdateData(int index, Matrix newTransform)
        {
            SetTransform(index, newTransform);
        }

        public void UndoData(int index, Matrix prevTransform)
        {
            // @todo: Figure out when to clear unmodified transforms, as this will continue to store transforms of meshes that
            //        were moved and then reverted

            SetTransform(index, prevTransform);
        }

        public bool GetTransform(int index, out Matrix outTransform)
        {
            outTransform = Matrix.Identity;
            if (!modifiedTransforms.ContainsKey(index))
                return false;

            outTransform = modifiedTransforms[index];
            return true;
        }

        public void SetTransform(int index, Matrix transform)
        {
            if (!modifiedTransforms.ContainsKey(index))
                modifiedTransforms.Add(index, Matrix.Identity);
            modifiedTransforms[index] = transform;
        }

        public Hkx.PolytopeShape GetOriginalCollison()
        {
            var first = inst64.Objects.OfType<Hkx.hknpConvexPolytopeShape>().FirstOrDefault();
            return first?.GetPolytopeShape();
        }

        public override byte[] SaveBytes()
        {
            inst64.Header.ModifiedArrays.Clear();

            var shapes = inst64.Objects.OfType<hknpConvexPolytopeShape>().ToList();
            bool collisionFits = true;

            MemoryStream ms = new MemoryStream();
            using (NativeWriter writer = new NativeWriter(ms))
            {
                writer.Write(resData);

                inst64.WriteObjects(writer);

                // write 32bit
                //{
                //    int index = 0;
                //    foreach (var instance in (inst32.Objects[0] as Hkx.hknpStaticCompoundShape).Instances)
                //    {
                //        Matrix transform;
                //        if (modifiedData.GetTransform(index, out transform))
                //        {
                //            var shape = instance.shape as Hkx.hknpShape;
                //            if (shape != null && (shape.unknown & 0x10) != 0)
                //            {
                //                transform = Matrix.Scaling(-1, 1, 1) * transform;
                //            }

                //            Vector3 scale;
                //            Vector3 translation;
                //            Quaternion rotation;
                //            Matrix rotationMatrix;

                //            transform.Decompose(out scale, out rotation, out translation);
                //            rotationMatrix = Matrix.RotationQuaternion(rotation);

                //            writer.Position = instance.DataOffset;

                //            writer.BaseStream.Position += 4; //writer.Write(rotationMatrix.M11);
                //            writer.BaseStream.Position += 4; //writer.Write(rotationMatrix.M12);
                //            writer.BaseStream.Position += 4; //writer.Write(rotationMatrix.M13);
                //            writer.BaseStream.Position += 4; //writer.Write(instance.tmp1);

                //            writer.BaseStream.Position += 4; //writer.Write(rotationMatrix.M21);
                //            writer.BaseStream.Position += 4; //writer.Write(rotationMatrix.M22);
                //            writer.BaseStream.Position += 4; //writer.Write(rotationMatrix.M23);
                //            writer.BaseStream.Position += 4; //writer.Write(instance.tmp2);

                //            writer.BaseStream.Position += 4; //writer.Write(rotationMatrix.M31);
                //            writer.BaseStream.Position += 4; //writer.Write(rotationMatrix.M32);
                //            writer.BaseStream.Position += 4; //writer.Write(rotationMatrix.M33);
                //            writer.BaseStream.Position += 4; //writer.Write(instance.tmp3);

                //            writer.Write(translation.X);
                //            writer.Write(translation.Y);
                //            writer.Write(translation.Z);
                //            writer.Write(instance.tmp4);

                //            writer.BaseStream.Position += 4; //writer.Write(scale.X);
                //            writer.BaseStream.Position += 4; //writer.Write(scale.Y);
                //            writer.BaseStream.Position += 4; //writer.Write(scale.Z);
                //        }
                //        index++;
                //    }
                //}

                if (ProfilesLibrary.DataVersion == (int)ProfileVersion.PlantsVsZombiesGardenWarfare)
                {
                    var shape = inst64.Objects.OfType<Hkx.hkpStaticCompoundShape>().FirstOrDefault();
                    if (shape != null)
                    {
                        for (int i = 0; i < shape.Instances.Count; i++)
                        {
                            if (!GetTransform(i, out var transform))
                                continue;

                            Vector3 scale;
                            Vector3 translation;
                            Quaternion rotation;

                            transform.Decompose(out scale, out rotation, out translation);

                            writer.Position = shape.Instances[i].DataOffset;

                            writer.Write(translation.X);
                            writer.Write(translation.Y);
                            writer.Write(translation.Z);
                            writer.BaseStream.Position += 4;

                            writer.Write(rotation.X);
                            writer.Write(rotation.Y);
                            writer.Write(rotation.Z);
                            writer.Write(rotation.W);

                            writer.Write(scale.X);
                            writer.Write(scale.Y);
                            writer.Write(scale.Z);
                        }
                    }
                }
                else
                {
                    // write 64bit
                    foreach (hkBaseClass obj in (inst64.Objects[0] as Hkx.HavokPhysicsContainer).Objects)
                    {
                        // reset the static compound shape data tree, this is a hack and is sure to come with some
                        // performance implications, but it works for now.

                        hknpStaticCompoundShape staticCompoundShape = obj as Hkx.hknpStaticCompoundShape;
                        if (staticCompoundShape == null)
                            continue;

                        if (staticCompoundShape.ShapeData != null && staticCompoundShape.ShapeData.ArrayOffset != -1)
                        {
                            writer.Position = staticCompoundShape.ShapeData.ArrayOffset;
                            for (int i = 0; i < staticCompoundShape.ShapeData.Unknowns.Count; i++)
                            {
                                writer.Write(new byte[] { 0x00, 0x00, 0x00 });
                                writer.BaseStream.Position += 3;
                            }
                        }

                        int index = 0;
                        foreach (hknpStaticCompoundShape.hknpInstance instance in (obj as Hkx.hknpStaticCompoundShape).Instances)
                        {
                            Matrix transform;
                            if (GetTransform(index, out transform))
                            {
                                hknpShape shape = instance.shape as Hkx.hknpShape;
                                if (shape != null && (shape.Flags & 4096) != 0)
                                {
                                    transform = Matrix.Scaling(-1, 1, 1) * transform;
                                }

                                Vector3 scale;
                                Vector3 translation;
                                Quaternion rotation;
                                Matrix rotationMatrix;

                                transform.Decompose(out scale, out rotation, out translation);
                                rotationMatrix = Matrix.RotationQuaternion(rotation);

                                writer.Position = instance.DataOffset;

                                writer.Write(rotationMatrix.M11);
                                writer.Write(rotationMatrix.M12);
                                writer.Write(rotationMatrix.M13);
                                writer.BaseStream.Position += 4;

                                writer.Write(rotationMatrix.M21);
                                writer.Write(rotationMatrix.M22);
                                writer.Write(rotationMatrix.M23);
                                writer.BaseStream.Position += 4;

                                writer.Write(rotationMatrix.M31);
                                writer.Write(rotationMatrix.M32);
                                writer.Write(rotationMatrix.M33);
                                writer.BaseStream.Position += 4;

                                writer.Write(translation.X);
                                writer.Write(translation.Y);
                                writer.Write(translation.Z);
                                writer.BaseStream.Position += 4;

                                writer.Write(scale.X);
                                writer.Write(scale.Y);
                                writer.Write(scale.Z);
                            }
                            index++;
                        }
                    }
                }

                if (Collision != null && shapes.Count != 0)
                {
                    if (!shapes[0].IsShapeValid(Collision))
                    {
                        App.Logger.LogError("New collision is invalid");
                    }
                    else if (!shapes[0].ShapeFits(Collision))
                    {
                        collisionFits = false;
                    }
                    else
                    {
                        shapes[0].Write(writer, Collision);
                        for (int i = 1; i < shapes.Count; i++)
                        {
                            shapes[i].Write(writer, new PolytopeShape());
                        }
                    }
                }
            }

            byte[] outBuffer = ms.ToArray();
            ms.Dispose();

            if (inst64.Header.ModifiedArrays.Count > 0)
            {
                int oldSize = inst64.AbsoluteDataStart + inst64.endOffset;

                byte[] newBytes = null;

                long dataStart = inst64.Header.StartOffset + inst64.AbsoluteDataStart;
                long insertAt = dataStart + inst64.VirtualFixupsOffset;

                var fixups = new Dictionary<long, long>(inst64.Header.ArrayOffsets);

                int delta;
                int tableDelta;

                using (var writer = new NativeWriter(new MemoryStream()))
                {
                    writer.Write(outBuffer, 0, (int)insertAt);

                    for (int i = 0; i < inst64.Header.ModifiedArrays.Count; i++)
                    {
                        var array = inst64.Header.ModifiedArrays[i];
                        long end = writer.Position;

                        if (inst64.Header.ArrayOffsets.TryGetValue(array.Offset, out long oldDataOffset) &&
                            array.Count <= BitConverter.ToInt32(resData, (int)array.Offset + 8))
                        {
                            writer.Position = oldDataOffset;
                            array.Write(writer);
                            writer.Position = end;
                            continue;
                        }

                        writer.WritePadding(16);
                        fixups[array.Offset] = writer.Position;
                        array.Write(writer);
                    }
                    writer.WritePadding(16);

                    delta = (int)(writer.Position - insertAt);

                    writer.Write(outBuffer, (int)insertAt, (int)(fixupTable64Pos - insertAt));

                    long tableStart = writer.Position;
                    foreach (var fixup in fixups.OrderBy(f => f.Key))
                    {
                        writer.Write((int)(fixup.Key - dataStart));
                        writer.Write((int)(fixup.Value - dataStart));
                    }
                    while ((writer.Position - tableStart) % 16 != 0)
                    {
                        writer.Write(-1);
                        writer.Write(-1);
                    }
                    tableDelta = (int)(writer.Position - tableStart) - inst64.GlobalFixupSize;

                    int restStart = (int)fixupTable64Pos + inst64.GlobalFixupSize;
                    writer.Write(outBuffer, restStart, outBuffer.Length - restStart);

                    writer.Position = inst64.SectionIntsPos + 4;
                    writer.Write(inst64.LocalFixupSize + tableDelta);
                    writer.Write(inst64.GlobalFixupSize + tableDelta);
                    writer.Write(inst64.VirtualFixupsOffset + delta);
                    writer.Write(inst64.exportsOffset + delta);
                    writer.Write(inst64.importsOffset + delta);
                    writer.Write(inst64.endOffset + delta);

                    writer.Position = fixupSizesPos + 4 + delta;
                    writer.Write(originalFixupSize64 + tableDelta);

                    newBytes = writer.ToByteArray();
                }

                outBuffer = newBytes;

                var stream = new MemoryStream();
                using (var writer = new NativeWriter(stream))
                {
                    writer.Write(resMeta);

                    writer.Position = 8;
                    writer.Write(oldSize + delta);
                    writer.Write((uint)(fixupTablesSize + tableDelta));
                }

                resMeta = stream.ToArray();
            }

            if (!collisionFits)
            {
                int oldSize = inst64.AbsoluteDataStart + inst64.endOffset;

                byte[] newBytes = null;

                long dataStart = inst64.Header.StartOffset + inst64.AbsoluteDataStart;
                long insertAt = dataStart + inst64.VirtualFixupsOffset;

                long[] headerOffsets =
                {
                    shapes[0].VerticesHeaderOffset,
                    shapes[0].PlanesHeaderOffset,
                    shapes[0].FacesHeaderOffset,
                    shapes[0].IndicesHeaderOffset
                };
                int[] counts =
                {
                    Collision.Vertices.Count,
                    Collision.Planes.Count,
                    Collision.Faces.Count,
                    Collision.Indices.Count
                };
                long[] dataOffsets = new long[4];

                using (var writer = new NativeWriter(new MemoryStream()))
                {
                    writer.Write(outBuffer, 0, (int)insertAt);

                    writer.WritePadding(16);
                    dataOffsets[0] = writer.Position;
                    foreach (var vert in Collision.Vertices)
                    {
                        writer.Write(vert.X);
                        writer.Write(vert.Y);
                        writer.Write(vert.Z);
                        writer.Write(vert.W);
                    }
                    writer.WritePadding(16);

                    dataOffsets[1] = writer.Position;
                    foreach (var plane in Collision.Planes)
                    {
                        writer.Write(plane.X);
                        writer.Write(plane.Y);
                        writer.Write(plane.Z);
                        writer.Write(plane.W);
                    }
                    writer.WritePadding(16);

                    dataOffsets[2] = writer.Position;
                    foreach (var face in Collision.Faces)
                    {
                        writer.Write(face.MinHalfAngle);
                        writer.Write(face.NumIndices);
                        writer.Write(face.FirstIndex);
                    }
                    writer.WritePadding(16);

                    dataOffsets[3] = writer.Position;
                    foreach (byte i in Collision.Indices)
                    {
                        writer.Write(i);
                    }
                    writer.WritePadding(16);

                    int delta = (int)(writer.Position - insertAt);

                    ushort[] offsets = new ushort[4];
                    for (int i = 0; i < 4; i++)
                    {
                        offsets[i] = (ushort)(dataOffsets[i] - headerOffsets[i]);
                    }

                    writer.Write(outBuffer, (int)insertAt, outBuffer.Length - (int)insertAt);

                    writer.Position = inst64.SectionIntsPos + 12;
                    writer.Write(inst64.VirtualFixupsOffset + delta);
                    writer.Write(inst64.exportsOffset + delta);
                    writer.Write(inst64.importsOffset + delta);
                    writer.Write(inst64.endOffset + delta);

                    for (int i = 0; i < 4; i++)
                    {
                        writer.Position = headerOffsets[i];
                        writer.Write((ushort)counts[i]);
                        writer.Write(offsets[i]);
                    }

                    newBytes = writer.ToByteArray();
                }

                if (newBytes != null)
                {
                    outBuffer = newBytes;

                    var stream = new MemoryStream();
                    using (var writer = new NativeWriter(stream))
                    {
                        writer.Write(resMeta);

                        writer.Position = 8;
                        writer.Write(oldSize + (outBuffer.Length - resData.Length));
                    }

                    resMeta = stream.ToArray();
                }
            }

            resEntry.ResMeta = resMeta;

            return outBuffer;
        }

        public Matrix GetTransform(int index)
        {
            Matrix outTransform;
            if (GetTransform(index, out outTransform))
                return outTransform;

            Matrix preScale = Matrix.Identity;
            if (ProfilesLibrary.DataVersion == (int)ProfileVersion.PlantsVsZombiesGardenWarfare)
            {
                hkpStaticCompoundShape shape = null;

                foreach (var obj in inst64.Objects)
                {
                    if (obj is hkpStaticCompoundShape match)
                    {
                        shape = match;
                        break;
                    }
                }

                if (shape == null)
                    return Matrix.Identity;

                var instance = shape.Instances[index];

                var quaternion = new Quaternion(instance.Rotation.X, instance.Rotation.Y, instance.Rotation.Z, instance.Rotation.W);

                Matrix transform =
                    Matrix.Scaling(instance.Scale) *
                    Matrix.RotationQuaternion(quaternion) *
                    Matrix.Translation(instance.Translation);

                return transform;
            }
            else
            {
                hknpStaticCompoundShape.hknpInstance instance = RootShape.Instances[(int)index];
                hknpShape shape = instance.shape as Hkx.hknpShape;

                if (shape != null && (shape.Flags & 4096) != 0)
                {
                    preScale = Matrix.Scaling(-1, 1, 1);
                }

                return
                    preScale *
                    Matrix.Scaling(instance.Scale) *
                    instance.Transform;
                //instance.Rotation * 
                //Matrix.Translation(instance.Translation);
            }
        }

        public string GetPhysicsShapeType(int index)
        {
            if (ProfilesLibrary.DataVersion == (int)ProfileVersion.PlantsVsZombiesGardenWarfare)
            {
                return "hkpStaticCompoundShape";
            }
            else
            {
                string placeholderName = "hknpConvexPolytopeShape";
                hknpStaticCompoundShape.hknpInstance instance = RootShape.Instances[index];

                // for some reason instance.shape when loading Zomburbia (GW2) is null, so it just uses a placeholder name
                return instance.shape == null ? placeholderName : instance.shape.GetType().Name;
            }
        }
    }
}