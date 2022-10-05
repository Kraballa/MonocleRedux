using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle
{
    public class SpecComponent<T> : Component where T : Entity
    {
        public T SpecEntity;

        public SpecComponent(bool active, bool visible) : base(active, visible)
        {
        }

        public override void Added(Entity entity)
        {
            base.Added(entity);
            if (entity is T)
                SpecEntity = entity as T;
        }

        public override void Removed(Entity entity)
        {
            SpecEntity = null;
            base.Removed(entity);
        }
    }
}
