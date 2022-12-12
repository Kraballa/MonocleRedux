using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public class Window
    {
        public Panel Panel { get; set; }
        public Vector2 Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public int Border { get; set; } = 4;

        public Vector2 InnerPosition => Position + new Vector2(Border, Border);
        public float InnerWidth => Width - Border * 2;
        public float InnerHeight => Height - Border * 2;

        public Window(Panel panel)
        {
            Panel = panel;
        }

        public virtual void Added()
        {
            Panel.Position = InnerPosition;
            Panel.Width = InnerWidth;
            Panel.Height = InnerHeight;
            Panel.Layout();
        }

        public virtual void Update()
        {

        }

        public virtual void Render()
        {
            Draw.Rect(Position, Width, Height, new Color(240, 240, 240));
            Draw.HollowRect(Position, Width, Height, new Color(140, 140, 140));

            Panel.Render();
        }
    }
}
