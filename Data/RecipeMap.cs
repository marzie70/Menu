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
    public class RecipeMap : IAutoMappingOverride<Recipe>
    {

        public void Override(AutoMapping<Recipe> mapping)
        {
            mapping.Id(m => m.ID).GeneratedBy.Assigned();
            mapping.Map(m => m.Name);
            mapping.Map(m => m.Quality);
        }
    }
}
