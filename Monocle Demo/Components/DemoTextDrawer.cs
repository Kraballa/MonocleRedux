using Monocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Components
{
    public class DemoTextDrawer : Component
    {

        private string Text { get; set; }
        public DemoTextDrawer(string text) : base(true, true)
        {
            Text = text;
        }

        public override void Render()
        {
            base.Render();
            Draw.DefaultFont.DrawString(Text, Microsoft.Xna.Framework.Vector2.One * 3);
        }
    }
}
