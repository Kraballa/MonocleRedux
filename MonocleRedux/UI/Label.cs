using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    /// <summary>
    /// A simple text label element.
    /// </summary>
    public class Label : Element
    {
        public string Text { get; set; }

        public Label() : this("")
        {

        }

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
