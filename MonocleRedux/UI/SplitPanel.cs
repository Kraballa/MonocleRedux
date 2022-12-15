using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public class SplitPanel : Panel
    {
        public Panel First { get; set; }
        public Panel Second { get; set; }
        public float Split { get; set; }

        public float SplitWidth = 8;
        public Orientation PanelAlignment;

        public SplitPanel(Panel first, Panel second, float split, Orientation panelAlignment) : base()
        {
            First = first;
            Second = second;
            Split = split;
            PanelAlignment = panelAlignment;
        }

        public override void Layout()
        {
            base.Layout();

            First.Position = InnerPosition;
            if (PanelAlignment == Orientation.Horizontal)
            {
                float width = InnerWidth - SplitWidth;
                First.Width = (int)(width * Split);
                First.Height = InnerHeight;

                Second.Width = (int)(width * (1 - Split));
                Second.Height = InnerHeight;
                Second.Position = InnerPosition + Vector2.UnitX * (InnerWidth - Second.Width);
            }
            else
            {
                float height = InnerHeight - SplitWidth;
                First.Height = (int)(height * Split);
                First.Width = InnerWidth;

                Second.Height = (int)(height * (1 - Split));
                Second.Width = InnerWidth;
                Second.Position = InnerPosition + Vector2.UnitY * (InnerHeight - Second.Height);
            }
            First.Layout();
            Second.Layout();
        }

        public override void Add(Element element)
        {
            throw new Exception("error, cannot accept elements");
        }

        public override void Update()
        {
            base.Update();
            First.Update();
            Second.Update();
        }

        public override void Render()
        {
            base.Render();
            First.Render();
            Second.Render();
            if (PanelAlignment == Orientation.Horizontal)
            {
                float offset = (InnerWidth - First.Width - Second.Width) / 2;
                Draw.Line(new Vector2(InnerPosition.X + First.Width + offset, InnerPosition.Y),
                    new Vector2(InnerPosition.X + First.Width + offset, InnerPosition.Y + InnerHeight), Color.Gray, 1f);
            }
            else
            {
                float offset = (InnerHeight - First.Height - Second.Height) / 2;
                Draw.Line(new Vector2(InnerPosition.X, InnerPosition.Y + First.Height + offset),
                    new Vector2(InnerPosition.X + InnerWidth, InnerPosition.Y + First.Height + offset), Color.Gray, 1f);
            }
        }
    }
}
