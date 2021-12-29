using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Monocle
{
    public class MultiTagRenderer : Renderer
    {
        public BitTag[] Tags;
        public BlendState BlendState;
        public SamplerState SamplerState;
        public Effect Effect;
        public Camera Camera;

        public MultiTagRenderer(params BitTag[] tags)
        {
            Tags = tags;
            BlendState = BlendState.AlphaBlend;
            SamplerState = SamplerState.LinearClamp;
            Camera = new Camera();
        }

        public override void BeforeRender(Scene scene)
        {

        }

        public override void Render(Scene scene)
        {
            Monocle.Render.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState, SamplerState, DepthStencilState.None, RasterizerState.CullNone, Effect, Camera.Matrix * Engine.ScreenMatrix);

            for(int i = 0; i < Tags.Length; i++)
            {
                foreach (var entity in scene[Tags[i]])
                    if (entity.Visible)
                        entity.Render();

                if (Engine.Commands.Open)
                    foreach (var entity in scene[Tags[i]])
                        entity.DebugRender(Camera);
            }

            Monocle.Render.SpriteBatch.End();
        }

        public override void AfterRender(Scene scene)
        {

        }
    }
}
