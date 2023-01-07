using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public class Image : Element
    {
        public enum FitType
        {
            /// <summary>
            /// scale and keep aspect ratio
            /// </summary>
            Fit,
            /// <summary>
            /// stretch image over the entire size of the element
            /// </summary>
            Stretch,
            /// <summary>
            /// place image in the center and don't scale
            /// </summary>
            Center
        }

        public MTexture Texture;
        public FitType Fit;

        public Image(MTexture tex, FitType type = FitType.Fit) : base()
        {
            Texture = tex;
            Fit = type;
        }

        public override void Render()
        {
            base.Render();
            Vector2 scale;

            switch (Fit)
            {
                case FitType.Fit:
                    scale = new Vector2(Math.Min(Width / Texture.Width, Height / Texture.Height));
                    Vector2 offset = new Vector2((Width - Texture.Width * scale.X) / 2, (Height - Texture.Height * scale.X) / 2);
                    Texture.Draw(Position + offset, Vector2.Zero, Color.White, scale);
                    break;
                case FitType.Stretch:
                    scale = new Vector2(Width / Texture.Width, Height / Texture.Height);
                    Texture.Draw(Position, Vector2.Zero, Color.White, scale);
                    break;
                case FitType.Center:
                    Texture.DrawCentered(Center);
                    break;
            }
        }
    }
}
