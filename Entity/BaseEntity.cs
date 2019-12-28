using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class BaseEntity
    {
        public virtual Guid ID { get; set; }

        public BaseEntity()
        {
            ID = Guid.NewGuid();
        }
    }
}
