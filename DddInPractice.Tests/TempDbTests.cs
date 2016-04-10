using System.IO;
using DddInPractice.Logic;
using DddInPractice.Logic.Management;
using DddInPractice.Logic.SnackMachines;
using DddInPractice.Logic.Utils;
using FluentAssertions;
using log4net.Config;
using NHibernate.Tool.hbm2ddl;
using Xunit;
using static DddInPractice.Logic.SharedKernel.Money;

namespace DddInPractice.Tests
{
    public class TempDbTests
    {
        private const string ConnectionString = @"Data Source=.\dev;Initial Catalog=SnackMachineDb;Integrated Security=SSPI;";

        public TempDbTests()
        {
            InitNHibernatProfiler();
            InitNHibernateSession();
        }

        private static void InitNHibernatProfiler()
        {
            var log4NetConfig = new FileInfo("./log4net.config");
            XmlConfigurator.Configure(log4NetConfig);
        }

        private static void InitNHibernateSession()
        {
            SessionFactory.Init(ConnectionString);
        }

        [Fact(Skip = "Do not recreate database each time this test runs.")]
        public void CreateDatabase()
        {
            SessionFactory.GetConfig(ConnectionString)
                .ExposeConfiguration(c => new SchemaExport(c).Execute(true, true, false))
                .BuildConfiguration();
        }

        [Fact(Skip = "Prevent unintentional queries to the database.")]
        public void GetSnackMachineAndBuySnackTest()
        {
            const long id = 1;
            var repository = new SnackMachineRepository();
            var snackMachine = repository.GetById(id);
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Dollar);
            snackMachine.BuySnack(1);
            repository.Save(snackMachine);
        }

        [Fact(Skip = "Test head office singleton instance by loading from database.")]
        public void CanLoadHeadCompanyInstance()
        {
            HeadOfficeInstance.Init();
            var office = HeadOfficeInstance.Instance;

            office.Should().NotBe(null);
            office.Id.Should().Be(1);
        }
    }
}