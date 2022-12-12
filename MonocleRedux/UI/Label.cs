using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public class Label : Element
    {
        public string Text { get; set; }

        public Label(string text)
        {
            Text = text;
        }

        public override void Render()
        {
            Draw.TextCentered(Manager.DefaultFont, Text, Center, Color.Black);
        }
    }
}
