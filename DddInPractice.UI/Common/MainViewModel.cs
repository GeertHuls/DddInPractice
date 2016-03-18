using DddInPractice.Logic;

namespace DddInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            SnackMachine snackMachine;
            using (var session = SessionFactory.OpenSession())
            {
                snackMachine = session.Get<SnackMachine>(1L);
            }

            var viewModel = new SnackMachineViewModel(snackMachine);
            DialogService.ShowDialog(viewModel);
        }
    }
}
