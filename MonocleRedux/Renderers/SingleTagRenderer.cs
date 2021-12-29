using Microsoft.Xna.Framework.Graphics;

namespace Monocle
{
    public class SingleTagRenderer : Renderer
    {
        public BitTag Tag;
        public BlendState BlendState;
        public SamplerState SamplerState;
        public Effect Effect;
        public Camera Camera;

        public SingleTagRenderer(BitTag tag)
        {
            Tag = tag;
            BlendState = BlendState.AlphaBlend;
            SamplerState = SamplerState.PointClamp;
            Camera = new Camera();
        }

        public override void BeforeRender(Scene scene)
        {

        }

        public override void Render(Scene scene)
        {
            Monocle.Render.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState, SamplerState, DepthStencilState.None, RasterizerState.CullNone, Effect, Camera.Matrix * Engine.ScreenMatrix);

            foreach (var entity in scene[Tag])
                if (entity.Visible)
                    entity.Render();

            if (Engine.Commands.Open)
                foreach (var entity in scene[Tag])
                    entity.DebugRender(Camera);

            Monocle.Render.SpriteBatch.End();
        }

        public override void AfterRender(Scene scene)
        {

        }
    }
}
