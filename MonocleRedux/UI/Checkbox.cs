using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public delegate void CheckboxChanged(bool newVal);

    public class Checkbox : Element
    {
        public int BoxSize = 18;

        public string Text { get; set; }
        public bool Value { get; set; }

        public event CheckboxChanged OnChanged;

        public Checkbox(string text, bool _default = false) : base()
        {
            Text = text;
            Value = _default;
            OnClick += () =>
            {
                Value = !Value;
                OnChanged?.Invoke(Value);
            };
        }

        public override void Render()
        {
            base.Render();
            Vector2 boxTl = Position + new Vector2(Height / 2, Height / 2);
            boxTl -= new Vector2(BoxSize / 2);
            Draw.HollowRect(boxTl, BoxSize, BoxSize, Color.Gray);
            if (Value == true)
            {
                Draw.Line(boxTl, boxTl + new Vector2(BoxSize, BoxSize), Color.Black, 2);
                Draw.Line(boxTl + new Vector2(BoxSize, 0), boxTl + new Vector2(0, BoxSize), Color.Black, 2);
            }
            Draw.TextJustify(Manager.DefaultFont, Text, new Vector2(Position.X + BoxSize + 12, Position.Y + Height / 2), new Vector2(0, 0.5f), Color.Black);
        }
    }
}
