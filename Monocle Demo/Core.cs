using Monocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Core : Engine
    {
        public Core(int width, int height, int windowWidth, int windowHeight, string windowTitle, bool fullscreen) : base(width, height, windowWidth, windowHeight, windowTitle, fullscreen)
        {
        }
    }
}
