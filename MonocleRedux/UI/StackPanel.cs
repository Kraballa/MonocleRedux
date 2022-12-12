using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Monocle.UI
{
    public enum Orientation
    {
        Vertical,
        Horizontal,
    }

    public class StackPanel : Panel
    {
        public Orientation Orientation { get; set; }
        public bool ExpandElements { get; set; }

        public StackPanel(Orientation ori = Orientation.Vertical)
        {
            Orientation = ori;
            if (Orientation == Orientation.Horizontal)
                ExpandElements = true;
        }

        public override void Add(Element element)
        {
            base.Add(element);
            if (Orientation == Orientation.Horizontal)
            {
                Height = Math.Max(element.Height + Border * 2, Height);
            }
        }

        public override void Layout()
        {
            if (Elements.Count <= 0)
                return;

            foreach (Element ele in Elements)
            {
                if (Orientation == Orientation.Vertical)
                {
                    ele.Width = (int)InnerWidth;
                }
                else
                {
                    ele.Height = (int)InnerHeight;
                }
            }

            if (ExpandElements)
            {
                float remaining;
                float size;
                if (Orientation == Orientation.Horizontal)
                {
                    remaining = InnerWidth - (Elements.Count - 1) * Margin;
                    size = remaining / Elements.Count;
                    float error = (remaining - ((int)size * Elements.Count)) / Elements.Count;
                    float cumuError = 0;
                    for (int i = 0; i < Elements.Count; i++)
                    {
                        Elements[i].Width = (int)size;
                        cumuError += error;
                        if (cumuError >= 0.999f)
                        {
                            Elements[i].Width++;
                            cumuError = 0;
                        }
                    }
                }
                else
                {
                    remaining = InnerHeight - (Elements.Count - 1) * Margin;
                    size = remaining / Elements.Count;
                    float error = (remaining - ((int)size * Elements.Count)) / Elements.Count;
                    float cumuError = 0;
                    for (int i = 0; i < Elements.Count; i++)
                    {
                        Elements[i].Height = (int)size;
                        cumuError += error;
                        if (cumuError >= 0.999f)
                        {
                            Elements[i].Width++;
                            cumuError = 0;
                        }
                    }
                }
            }

            Vector2 pos = InnerPosition;
            if (Orientation == Orientation.Horizontal)
            {
                for (int i = 0; i < Elements.Count; i++)
                {
                    Elements[i].Position = pos;
                    pos.X += Elements[i].Width + Margin;
                }
            }
            else
            {
                for (int i = 0; i < Elements.Count; i++)
                {
                    Elements[i].Position = pos;
                    pos.Y += Elements[i].Height + Margin;
                }
            }

            base.Layout();
        }
    }
}
