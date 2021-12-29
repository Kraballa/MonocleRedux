using Demo.Components;
using Monocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Scenes
{
    public class DemoScene : Scene
    {
        public DemoScene() : base()
        {
            Add(new EverythingRenderer());
            HelperEntity.Add(new DemoTextDrawer("Hello World!"));
            HelperEntity.Add(new ScreenMeasureRenderer());
        }
    }
}
