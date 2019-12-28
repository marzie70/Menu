using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Food : BaseEntity
    {
        public Food()
        {
            recipes = new List<Recipe>();
        }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal Quality { get; set; }
        public virtual ICollection<Recipe> recipes { get; set; }

    }
}
