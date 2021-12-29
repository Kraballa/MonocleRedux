using Microsoft.Xna.Framework;
using Monocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Components
{
    public class ScreenMeasureRenderer : Component
    {
        public ScreenMeasureRenderer() : base(true, true)
        {
        }

        public override void Render()
        {
            base.Render();
            Draw.HollowRect(0, 0, Engine.Width, Engine.Height, Color.White);
            Draw.HollowRect(1, 1, Engine.Width - 2, Engine.Height - 2, Color.White);
        }
    }
}
