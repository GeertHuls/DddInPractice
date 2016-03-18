using DddInPractice.Logic;

namespace DddInPractice.UI
{
    public partial class App
    {
        public App()
        {
            Initer.Init(@"Data Source=.\dev;Initial Catalog=SnackMachineDb;Integrated Security=SSPI;");
        }
    }
}
