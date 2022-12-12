using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public class TabPanel : Panel
    {
        public List<Panel> Panels = new List<Panel>();
        public List<string> Titles = new List<string>();

        public int CurrentPanel = 0;
        public int TabTitleMargin = 12;

        public float TabBarHeight;
        public override Vector2 InnerPosition => base.InnerPosition + Vector2.UnitY * TabBarHeight;
        public override float InnerHeight => base.InnerHeight - TabBarHeight;

        public TabPanel()
        {
            TabBarHeight = Manager.DefaultFont.CharHeight + TabTitleMargin * 2;
        }

        public void AddTab(Panel panel, string title)
        {
            Panels.Add(panel);
            Titles.Add(title);
        }

        public override void Add(Element element)
        {
            throw new Exception("error, cannot accept an element, use `AddTab` instead");
        }

        public override void Layout()
        {
            foreach (Panel panel in Panels)
            {
                panel.Width = InnerWidth;
                panel.Height = InnerHeight;
                panel.Position = InnerPosition;
                panel.Layout();
            }
        }

        public override void Update()
        {
            base.Update();

            Rectangle rect = new Rectangle();
            rect.X = (int)Position.X;
            rect.Y = (int)Position.Y;
            rect.Height = (int)TabBarHeight;
            for (int i = 0; i < Panels.Count; i++)
            {
                rect.Width = Titles[i].Length * Manager.DefaultFont.CharWidth + TabTitleMargin * 2;
                if (Manager.Mouse.Pressed && rect.Contains(MInput.Mouse.Position.ToPoint()))
                {
                    CurrentPanel = i;
                }
                rect.X += rect.Width;
            }

            if (Panels.Count > CurrentPanel)
            {
                Panels[CurrentPanel].Update();
            }
        }

        public override void Render()
        {
            base.Render();
            Draw.Line(new Vector2(Position.X, Position.Y + TabBarHeight - 1), new Vector2(Position.X + Width, Position.Y + TabBarHeight - 1), Color.Gray);
            float x = Position.X;
            float y = Position.Y;
            for (int i = 0; i < Titles.Count; i++)
            {
                float textWidth = Titles[i].Length * Manager.DefaultFont.CharWidth;

                if (i == CurrentPanel)
                {
                    Draw.HollowRect(x, y, textWidth + TabTitleMargin * 2, TabBarHeight, Color.Gray);
                    Draw.Rect(x + 1, y + 1, textWidth + TabTitleMargin * 2 - 2, TabBarHeight - 1, new Color(240, 240, 240));
                }
                else
                {
                    Draw.Rect(x, y + 2, textWidth + TabTitleMargin * 2, TabBarHeight - 2, new Color(210, 210, 210));
                    Draw.HollowRect(x, y + 2, textWidth + TabTitleMargin * 2, TabBarHeight - 2, Color.Gray);
                }

                x += TabTitleMargin;
                Draw.Text(Manager.DefaultFont, Titles[i], new Vector2(x, y + TabTitleMargin + (CurrentPanel != i ? 2 : 0)), Color.Black);
                x += Titles[i].Length * Manager.DefaultFont.CharWidth + TabTitleMargin;
            }


            if (Panels.Count > CurrentPanel)
            {
                Panels[CurrentPanel].Render();
            }
        }
    }
}
