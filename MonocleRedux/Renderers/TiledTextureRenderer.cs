using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.Renderers
{
    public class TiledTextureRenderer : Renderer
    {
        public MTexture Texture { get; set; }
        public BlendState BlendState;
        public SamplerState SamplerState;
        public Effect Effect;
        public Camera Camera;

        public TiledTextureRenderer(MTexture tex) : base()
        {
            Texture = tex;
            BlendState = BlendState.AlphaBlend;
            SamplerState = SamplerState.PointWrap;
            Camera = new Camera();
        }

        public override void BeforeRender(Scene scene)
        {

        }

        public override void Render(Scene scene)
        {
            Monocle.Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState, SamplerState, DepthStencilState.None, RasterizerState.CullNone, Effect, Camera.Matrix * Engine.ScreenMatrix);

            float width = Engine.Width * 2;
            float height = Engine.Height * 2;

            Rectangle rect = new Rectangle((int)Camera.X, (int)Camera.Y, (int)width, (int)height);
            Draw.SpriteBatch.Draw(Texture.Texture, Camera.Position - new Vector2(width / 2, height / 2), rect, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);

            Monocle.Draw.SpriteBatch.End();
        }

        public override void AfterRender(Scene scene)
        {

        }
    }
}
