using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Silk.NET.Core;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;


namespace VoxelTest
{
    public class Game
    {
        private static IWindow _window;
        private static GL _gl;
        static void Main(string[] args)
        {
            var options = WindowOptions.Default;
            Console.WriteLine("Hello World!");
            options.Title = "Voxel Test";   
            options.Size = new Silk.NET.Maths.Vector2D<int>(800, 600);
            options.API = new GraphicsAPI(ContextAPI.OpenGL, ContextProfile.Core, ContextFlags.Debug, new APIVersion(3, 3));

            _window = Window.Create(options);
            _window.Run();
        }
    }
}
