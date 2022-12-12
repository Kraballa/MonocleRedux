using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public abstract class Panel : Element
    {
        public List<Element> Elements = new List<Element>();

        public int Border { get; set; } = 2;
        public int Margin { get; set; } = 2;

        public virtual Vector2 InnerPosition => Position + new Vector2(Border, Border);
        public virtual float InnerWidth => Width - Border * 2;
        public virtual float InnerHeight => Height - Border * 2;

        public virtual void Add(Element element)
        {
            Elements.Add(element);
        }

        public override void Render()
        {
            base.Render();
            Elements.ForEach((e) => e.Render());
        }

        public override void Layout()
        {
            base.Layout();
            foreach (Element ele in Elements)
            {
                ele.Layout();
            }
        }
    }
}
