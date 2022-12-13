using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public class Button : Label
    {
        public Button(string text) : base(text)
        {
        }

        public override void Render()
        {
            if (Hovered())
            {
                Draw.Rect(Position, Width, Height, Color.CadetBlue);
                Draw.HollowRect(Position, Width, Height, Color.DarkBlue);
            }
            else
            {
                Draw.Rect(Position, Width, Height, Color.DarkGray);
                Draw.HollowRect(Position, Width, Height, Color.Gray);
            }
            base.Render();
        }
    }
}
