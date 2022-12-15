﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public enum WindowAlignment
    {
        None,
        TopRight,
        TopCenter,
        TopLeft,
        CenterRight,
        Center,
        CenterLeft,
        BottomRight,
        BottomCenter,
        BottomLeft
    }

    /// <summary>
    /// The base frame that contains the top level panel.
    /// </summary>
    public class Window
    {
        public Panel Panel { get; set; }
        public Vector2 Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public int Border { get; set; } = 4;

        public virtual Vector2 InnerPosition => Position + new Vector2(Border, Border);
        public float InnerWidth => Width - Border * 2;
        public float InnerHeight => Height - Border * 2;
        public WindowAlignment Alignment = WindowAlignment.None;

        public Window(Panel panel)
        {
            Panel = panel;
        }

        public virtual void Added()
        {
            Align();
            Panel.Position = InnerPosition;
            Panel.Width = InnerWidth;
            Panel.Height = InnerHeight;
            Panel.Layout();
        }

        public virtual void Update()
        {
            Panel.Update();
        }

        public virtual void Render()
        {
            Draw.Rect(Position, Width, Height, new Color(240, 240, 240));
            Draw.HollowRect(Position, Width, Height, new Color(140, 140, 140));

            Panel.Render();
        }

        protected void Align()
        {
            switch (Alignment)
            {
                case WindowAlignment.TopRight:
                    Position = new Vector2(Engine.Width - Width, 0);
                    break;
                case WindowAlignment.TopCenter:
                    Position = new Vector2(Engine.Width / 2 - Width / 2, 0);
                    break;
                case WindowAlignment.TopLeft:
                    Position = Vector2.Zero;
                    break;
                case WindowAlignment.CenterRight:
                    Position = new Vector2(Engine.Width - Width, Engine.Height / 2 - Height / 2);
                    break;
                case WindowAlignment.Center:
                    Position = new Vector2(Engine.Width / 2 - Width / 2, Engine.Height / 2 - Height / 2);
                    break;
                case WindowAlignment.CenterLeft:
                    Position = new Vector2(0, Engine.Height / 2 - Height / 2);
                    break;
                case WindowAlignment.BottomRight:
                    Position = new Vector2(Engine.Width - Width, Engine.Height - Height);
                    break;
                case WindowAlignment.BottomCenter:
                    Position = new Vector2(Engine.Width / 2 - Width / 2, Engine.Height - Height);
                    break;
                case WindowAlignment.BottomLeft:
                    Position = new Vector2(0, Engine.Height - Height);
                    break;
            }
        }
    }
}
