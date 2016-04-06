using DddInPractice.Logic;
using DddInPractice.Logic.Utils;

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
