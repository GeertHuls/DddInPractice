using DddInPractice.Logic;
using DddInPractice.Logic.SnackMachines;

namespace DddInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            var snackMachine = new SnackMachineRepository().GetById(1);

            var viewModel = new SnackMachineViewModel(snackMachine);
            DialogService.ShowDialog(viewModel);
        }
    }
}
