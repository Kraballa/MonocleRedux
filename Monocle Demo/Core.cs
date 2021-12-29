using Demo.Components;
using Demo.Scenes;
using Microsoft.Xna.Framework;
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
        public Core() : base(320, 180, 1280, 720, "Monocle Redux Demo", false)
        {
            ClearColor = Color.Black;
            Scene = new DemoScene();
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
    }
}
