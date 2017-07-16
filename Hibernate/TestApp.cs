using NHibernate.Cfg;
using Hibernate.Domain;
using System;
using System.Reflection;

namespace Hibernate
{
    public class TestApp
    {
        public static string Main()
        {            
            var configuration = new Configuration()
                .Configure("Mappings/hibernate.cfg.xml")
                .AddAssembly("Hibernate")
                .BuildSessionFactory();


            var nhnSession = configuration.OpenSession();

            // Test
            return nhnSession.Get<Employee>(16).EmployeeName;
        }
    }
}
