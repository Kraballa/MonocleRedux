using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle
{
    internal class AnimatedImage : Image
    {
        public enum EndBehavior
        {
            Loop,
            Freeze,
            Hide
        }


        public MTexture Source { get; set; }
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }

        /// <summary>
        /// Counts until the next frame gets displayed
        /// </summary>
        private float FrameCounter { get; set; }

        /// <summary>
        /// How long each frame lingers
        /// </summary>
        private float FrameDuration { get; set; }

        /// <summary>
        /// number of frames in the animation
        /// </summary>
        private int NumFrames { get; set; }

        /// <summary>
        /// index of the current frame
        /// </summary>
        private int FrameIndex { get; set; }

        private bool Stop { get; set; } = false;

        private EndBehavior Behavior { get; set; }

        public AnimatedImage(MTexture texture, int frameWidth, int frameHeight, float animDuration, EndBehavior behavior = EndBehavior.Hide) : base(texture)
        {
            Source = texture;

            FrameWidth = frameWidth;
            FrameHeight = frameHeight;

            int NumFrames = Source.Width / FrameWidth;

            FrameDuration = animDuration / NumFrames;

            Behavior = behavior;


            Texture = GetFrame(0);
        }

        public override void Update()
        {
            base.Update();

            if (Stop)
                return;

            FrameCounter += Engine.DeltaTime;
            if(FrameCounter >= FrameDuration)
            {
                if(FrameIndex < NumFrames-1)
                {
                    FrameIndex++;
                    Texture = GetFrame(FrameIndex);
                    FrameCounter -= NumFrames;
                }
                else //ran out of frames
                {
                    switch (Behavior)
                    {
                        case EndBehavior.Loop:
                            FrameIndex = 0;
                            FrameCounter -= NumFrames;
                            Texture = GetFrame(FrameIndex);
                            break;
                        default:
                        case EndBehavior.Freeze:
                            Stop = true;
                            break;
                        case EndBehavior.Hide:
                            Stop = true;
                            Visible = false;
                            break;
                    }
                }
            }
        }

        private MTexture GetFrame(int index)
        {
            return new MTexture(Source, FrameWidth * index, 0, FrameWidth, FrameHeight);
        }
    }
}
