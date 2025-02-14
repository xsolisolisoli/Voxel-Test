using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Design;
using OpenTK;

namespace VoxelTest.Geometry
{
    public class BlockVertices
    {
        private int vbo, ebo;
        private uint[] indices;
        private float angle = 0.0f;

        public MainForm()
        {

        }
        public void GLControl_Paint(object sender, PaintValueEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelview = Matrix4.LookAt(
                new Vector3(0, 0, 5), // Camera position
                Vector3.Zero,         // Look at origin
                Vector3.UnitY);       // Up vector

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            GL.Rotate(angle, Vector3.UnitY);
            GL.Rotate(angle * 0.5f, Vector3.UnitX);

            GL.Color3(Color.White);
            GL.EnableClientState(ArrayCap.VertexArray);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.VertexPointer(3, VertexPointerType.Float, 0, IntPtr.Zero);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.DrawElements(PrimitiveType.Lines, indices.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);

            GL.DisableClientState(ArrayCap.VertexArray);
            SwapBuffers();
        }
        public static void RenderBlock()
        {
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.LineSmooth);
            GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
            GL.LineWidth(1.5f);

            // Define cube vertices and indices
            float[] vertices = new float[]
            {
            -1, -1, -1,  // 0
             1, -1, -1,  // 1
             1,  1, -1,  // 2
            -1,  1, -1,  // 3
            -1, -1,  1,  // 4
             1, -1,  1,  // 5
             1,  1,  1,  // 6
            -1,  1,  1   // 7
            };

            indices = new uint[]
            {
            0,1,1,2,2,3,3,0, // Front
            4,5,5,6,6,7,7,4, // Back
            0,4,1,5,2,6,3,7  // Connections
            };

            // Generate VBO and EBO
            GL.GenBuffers(1, out vbo);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * sizeof(float)), vertices, BufferUsageHint.StaticDraw);

            GL.GenBuffers(1, out ebo);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(uint)), indices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);



        }
    }
}
