using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public class Manager : Entity
    {
        public static BitmapFont DefaultFont;
        public static VirtualButton Mouse;

        private List<Window> UIStack = new List<Window>();
        private List<Window> UIBase = new List<Window>();

        public Manager() : base()
        {
            DefaultFont = Draw.DefaultFont;
        }

        /// <summary>
        /// Add a permanent panel that sits under the layered stack system.
        /// </summary>
        public void Add(Window element)
        {
            UIBase.Add(element);
            element.Added();
        }

        /// <summary>
        /// push a new panel ontop of the ui stack causing it to pull focus
        /// </summary>
        public void Push(Window element)
        {
            UIStack.Add(element);
            element.Added();
        }

        public void Pop()
        {
            if (UIStack.Count > 0)
                UIStack.RemoveAt(UIStack.Count - 1);
        }

        /// <summary>
        /// update the topmost panel
        /// </summary>
        public override void Update()
        {
            base.Update();
            if (UIStack.Count > 0)
                UIStack[UIStack.Count - 1].Update();
            else
            {
                UIBase.ForEach((e) => e.Update());
            }
        }

        /// <summary>
        /// render panels in order
        /// </summary>
        public override void Render()
        {
            base.Render();
            UIBase.ForEach((e) => e.Render());
            for (int i = 0; i < UIStack.Count; i++)
            {
                UIStack[i].Render();
            }
        }
    }
}
