using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using Project1.Geometry;


namespace VoxelTest
{
    public class Game : GameWindow
    {
        public Game()
            : base(800, 600, GraphicsMode.Default, "Voxel Test", GameWindowFlags.Default, DisplayDevice.Default, 3, 3, GraphicsContextFlags.Debug)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.CornflowerBlue);
            Console.WriteLine("GAME::OnLoad Called");
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            Console.WriteLine("GAME::OnUpdate Called");

            var input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Console.WriteLine("GAME::OnRender Called");
            SwapBuffers();
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            Console.WriteLine("GAME::KeyDown Called");
        }

        [STAThread]
        public static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run(60.0);
            }
        }
    }
}