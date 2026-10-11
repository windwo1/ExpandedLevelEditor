using SharpDX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditorPlugin.Library
{
    // Credit to Magix for WavefrontObj!:
    // https://github.com/MagixGames/FrostyHavokPlugin/blob/master/HavokFb/WavefrontObj.cs
    public class WavefrontObj
    {
        public struct Face
        {
            public List<int> Indices;


            public Face(params int[] indices)
            {
                Indices = indices.ToList();
            }

            public void Add(int _vert)
            {
                Indices.Add(_vert);
            }
            public void Set(List<int> list)
            {
                Indices = list;
            }
            public void Offset(int amt)
            {
                if (amt == 0)
                {
                    return;
                }
                for (int i = 0; i < Indices.Count; i++)
                {
                    Indices[i] += amt;
                }
            }

            public List<Face> AsTris()
            {
                return new List<Face>();
            }

            public string Build()
            {
                string s = "";
                foreach (int i in Indices)
                {
                    s += $"{i} ";
                }
                return s;
            }
            public IEnumerable<int> Get()
            {
                foreach (int i in Indices)
                {
                    yield return i;
                }
            }

        }

        public List<Vector4> Vertices;
        public List<Face> Faces;

        public WavefrontObj()
        {
            Vertices = new List<Vector4>();
            Faces = new List<Face>();
        }

        public static List<WavefrontObj> ReadFromFile(string file) => Read(File.ReadAllText(file));
        public static List<WavefrontObj> Read(string text)
        {
            string[] parse = text.Split('\n');
            int pos = 0;
            bool alreadyHitObj = false;
            List<WavefrontObj> objects = new List<WavefrontObj>();
            WavefrontObj current = new WavefrontObj();

            while (pos < parse.Length)
            {
                string line = parse[pos++];
                string[] spaced = line.Split(' ');
                if (line.Length <= 2)
                {
                    pos++;
                    continue;
                }
                if (spaced[0].Length > 1)
                {
                    continue;
                }
                switch (line[0])
                {
                    case 'v':
                        {
                            float x = Convert.ToSingle(spaced[1]);
                            float y = Convert.ToSingle(spaced[2]);
                            float z = Convert.ToSingle(spaced[3]);
                            float w = 0.5f;

                            // is Vec4
                            if (spaced.Length >= 5)
                            {
                                w = Convert.ToSingle(spaced[4]);
                            }


                            current.Vertices.Add(new Vector4(x, y, z, w));
                            break;
                        }
                    case 'f':
                        {
                            string buff = line.Substring(2);

                            List<int> list = buff.Replace('/', ' ').Split(' ').Select((s) => Convert.ToInt32(s)).ToList();
                            Face face = new Face();
                            face.Set(list);
                            current.Faces.Add(face);

                            break;
                        }
                    case 'o':
                        {
                            // First object in .obj
                            if (!alreadyHitObj)
                            {
                                alreadyHitObj = true;
                                break;
                            }

                            objects.Add(current);

                            current = new WavefrontObj();
                            break;
                        }
                    default:
                        pos++;
                        break;

                }
            }
            objects.Add(current);

            return objects;
        }

        public IEnumerable<List<Vector4>> GetFaces()
        {
            foreach (Face face in Faces)
            {
                List<Vector4> points = new List<Vector4>();
                foreach (int indice in face.Get())
                {
                    points.Add(Vertices[indice - 1]);
                }
                yield return points;
            }
        }


        public static WavefrontObj Combine(List<WavefrontObj> list)
        {
            WavefrontObj obj = new WavefrontObj();

            foreach (WavefrontObj item in list)
            {
                int verticesCount = obj.Vertices.Count;
                int facesCount = obj.Faces.Count;

                obj.Vertices.AddRange(item.Vertices);
                obj.Faces.AddRange(item.Faces);
                //foreach (Face face in item._faces)
                //{
                //    //face.Offset(verticesCount);
                //    obj._faces.Add(face);
                //}
            }

            return obj;
        }

        public void ForceTris()
        {
            List<Face> newFaces = new List<Face>();

            foreach (Face face in Faces)
            {
                // More than 3 vertices
                if (face.Indices.Count > 3)
                {
                    List<Face> split = new List<Face>();

                    for (int i = 1; i < face.Indices.Count - 1; i++)
                    {
                        split.Add(new Face(face.Indices.First(), face.Indices[i], face.Indices[i + 1]));
                    }
                    newFaces.AddRange(split);

                    continue;
                }

                // Is a tri, add as it is
                newFaces.Add(face);
            }
            Faces.Clear();
            Faces = newFaces;
        }
    }
}
