using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public delegate void Clicked();

    public class Element
    {
        public Vector2 Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Vector2 Center => Position + new Vector2(Width / 2, Height / 2);

        public event Clicked OnClick;

        public Element()
        {
            //some default values
            Width = 80;
            Height = 26;
        }

        public virtual void Layout()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Render()
        {

        }

        public bool Hovered()
        {
            Vector2 pos = MInput.Mouse.Position;
            return pos.X >= Position.X && pos.Y >= Position.Y && pos.X <= Position.X + Width && pos.Y <= Position.Y + Height;
        }
    }
}
