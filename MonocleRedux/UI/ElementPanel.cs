using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    /// <summary>
    /// An abstract implementation of a panel that can accept elements.
    /// </summary>
    public abstract class ElementPanel : Panel
    {
        public List<Element> Elements = new List<Element>();

        public ElementPanel() : base()
        {

        }

        public virtual void Add(Element element)
        {
            Elements.Add(element);
        }

        public override void Render()
        {
            base.Render();
            Elements.ForEach((e) => e.Render());
        }

        public override void Update()
        {
            Elements.ForEach((e) => e.Update());
            base.Update();
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
