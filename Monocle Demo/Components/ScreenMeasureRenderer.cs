using Microsoft.Xna.Framework;
using Monocle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Components
{
    public class ScreenMeasurer : Component
    {
        public ScreenMeasurer() : base(true, true)
        {
        }

        public override void Render()
        {
            base.Render();
            Vector2 mPos = MInput.Mouse.Position;
            Draw.Line(new Vector2(mPos.X, 0), new Vector2(mPos.X, Engine.Height), Color.Black);
            Draw.Line(new Vector2(0, mPos.Y), new Vector2(Engine.Width, mPos.Y), Color.Black);
            Draw.Circle(mPos, 8.5f, Color.Black, 3);

            string text = string.Format("size: {0}x{1}\nview: {2}x{3}", Engine.Width, Engine.Height, Engine.ViewWidth, Engine.ViewHeight);
            Draw.DefaultFont.DrawString(text, new Vector2((Engine.Width - Draw.DefaultFont.MeasureString(text).X) / 2, 3), Color.Black);

            Draw.HollowRect(0, 0, Engine.Width, Engine.Height, Color.Black);
            Draw.HollowRect(1, 1, Engine.Width - 2, Engine.Height - 2, Color.Black);
        }
    }
}
