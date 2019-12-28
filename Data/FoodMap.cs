using Entity;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FoodMap : IAutoMappingOverride<Food>
    {
        public void Override(AutoMapping<Food> mapping)
        {
            mapping.Id(m => m.ID).GeneratedBy.Assigned();
            mapping.Map(m => m.Name);
            mapping.Map(m => m.Price);
            mapping.Map(m => m.Quality);
        }
    }
}
