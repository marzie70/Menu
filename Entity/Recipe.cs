using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Recipe : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual decimal Quality { get; set; }
    }
}
