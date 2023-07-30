using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    /// <summary>
    /// A Button is an element with specific rendering to appear like an ordinary button and reacting to being hovered.
    /// </summary>
    public class Button : Label
    {
        public Button(string text) : base(text)
        {
        }

        public override void Render()
        {
            Color border;
            Color bg;

            if (Hovered())
            {
                if (Manager.Mouse != null && Manager.Mouse.Check)
                {
                    bg = Color.LightBlue;
                    border = Color.CadetBlue;
                }
                else
                {
                    bg = Color.CadetBlue;
                    border = Color.DarkBlue;
                }
            }
            else
            {
                bg = Color.DarkGray;
                border = Color.Gray;
            }
            Draw.Rect(Position, Width, Height, bg);
            Draw.HollowRect(Position, Width, Height, border);
            base.Render();
        }
    }
}
