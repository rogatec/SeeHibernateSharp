using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate;
using System.Reflection;
using NHibernate.Dialect;
using NHibernate.Bytecode;
using Hibernate.Domain;
using NHibernate.Driver;

namespace SeeHibernateSharpTests
{
    [TestClass]
    public class HibernateTest : IDisposable
    {
        private static Configuration configuration;
        private static ISessionFactory sessionFactory;
        protected ISession session;

        public void Dispose()
        {
            session.Dispose();
        }

        public HibernateTest()
        {
            Setup(typeof(Hibernate.TestApp).Assembly);
        }

        public void Setup(Assembly assemblyContainingMapping)
        {
            if (configuration == null)
            {
                configuration = new Configuration()
                    .SetProperty(NHibernate.Cfg.Environment.ReleaseConnections, "on_close")
                    .SetProperty(NHibernate.Cfg.Environment.Dialect, typeof(MsSql2012Dialect).AssemblyQualifiedName)
                    .SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, typeof(SqlClientDriver).AssemblyQualifiedName)
                    .SetProperty(NHibernate.Cfg.Environment.ConnectionString, "Data Source=.\\SQLTEC;DataBase=WideWorldImportersDW;Integrated Security=SSPI")
                    .AddAssembly(assemblyContainingMapping);

                sessionFactory = configuration.BuildSessionFactory();
            }

            session = sessionFactory.OpenSession();
        }

        [TestMethod]
        public void CanLoadEmployeeById()
        {
            using (var tx = session.BeginTransaction())
            {
                var employee = session.Get<Employee>(16);

                Assert.AreEqual("Katie Darwin", employee.EmployeeName);
                Assert.AreEqual("Katie", employee.PreferredName);
                Assert.AreEqual(false, employee.IsSalesperson);
            }
        }
    }
}
