using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public class ProgressBar : Element
    {
        public const int MAX_VALUE = 100;
        public const int MIN_VALUE = 0;

        public int Value
        {
            get => _value;
            set
            {
                _value = Math.Clamp(value, MIN_VALUE, MAX_VALUE);
            }
        }

        private int _value;

        public ProgressBar(int value = 0) : base()
        {
            Value = value;
            Height = 16;
        }

        public override void Render()
        {
            base.Render();
            Draw.Rect(Position, Width, Height, Color.LightGray);
            float width = Width * ((float)Value / MAX_VALUE);
            Draw.Rect(Position, width, Height, Color.Green);
            Draw.HollowRect(Position, Width, Height, Color.Gray);

        }
    }
}
