using DddInPractice.Logic;
using NHibernate.Tool.hbm2ddl;
using Xunit;

namespace DddInPractice.Tests
{
    public class TempDbTests
    {
        private readonly string _connectionString= @"Data Source=.\dev;Initial Catalog=SnackMachineDb;Integrated Security=SSPI;";

        [Fact]
        public void CreateDatabase()
        {
            SessionFactory.GetConfig(_connectionString)
                .ExposeConfiguration(c => new SchemaExport(c).Execute(true, true, false))
                .BuildConfiguration();
        }

        [Fact]
        public void Test()
        {
            SessionFactory.Init(_connectionString);

            using (var session = SessionFactory.OpenSession())
            {
                long id = 1;
                var snackMachine = session.Get<SnackMachine>(id);
            }
        }
    }
}