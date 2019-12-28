using Entity;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class NHibernateHelper : DefaultAutomappingConfiguration
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var connectionString = String.Empty;
                    var cfgi = new StoreConfiguration();
                    var fluentConfiguration = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012
                            .ConnectionString(@"Data Source=.\SQL2019;Initial Catalog=FoodRecipe;Integrated Security=True;Pooling=False")
                            .ShowSql()
                        );
                    var configuration = fluentConfiguration.Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Food>(cfgi).
                        UseOverridesFromAssemblyOf<FoodMap>()));
                    var buildSessionFactory = configuration.ExposeConfiguration(cfg =>
                    {
                        new SchemaUpdate(cfg).Execute(false, true);
                        new SchemaExport(cfg)
                            .Create(true, true);
                    })
                        .BuildSessionFactory();
                    _sessionFactory = buildSessionFactory;
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
