using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public class Splitter : Element
    {
        public Orientation Orientation { get; set; }

        public Splitter(Orientation orientation)
        {
            Orientation = orientation;
            if (orientation == Orientation.Horizontal)
            {
                Height = 8;
            }
            else
            {
                Width = 8;
            }
        }

        public override void Render()
        {
            base.Render();
            if (Orientation == Orientation.Horizontal)
            {
                Draw.Line(Position + new Vector2(0, Height / 2), Position + new Vector2(Width, Height / 2), Color.Gray);
            }
            else
            {
                Draw.Line(Position + new Vector2(Width / 2, 0), Position + new Vector2(Width / 2, Height), Color.Gray);
            }
        }
    }
}
