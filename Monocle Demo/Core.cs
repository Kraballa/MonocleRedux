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
        public Core() : base(1920, 1080, 1920, 1080, "Monocle Redux Demo", false)
        {
            ClearColor = Color.White;

            IsMouseVisible = true;
            Window.AllowUserResizing = false;
            IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {
            base.Initialize();

            //initialize tags
            new BitTag("ui");

            Scene = new DemoScene();
        }
    }
}
