using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    /// <summary>
    /// A Panel is responsible to contain and layout child elements. Whether those are panels or interactable elements is up to the implementation.
    /// </summary>
    public abstract class Panel : Element
    {
        /// <summary>
        /// Space between the outer edge of the panel and the content inside the panel
        /// </summary>
        public int Border { get; set; } = 2;

        /// <summary>
        /// Space inbetween each element inside the panel
        /// </summary>
        public int Margin { get; set; } = 2;

        public virtual Vector2 InnerPosition => Position + new Vector2(Border, Border);
        public virtual float InnerWidth => Width - Border * 2;
        public virtual float InnerHeight => Height - Border * 2;
    }
}
