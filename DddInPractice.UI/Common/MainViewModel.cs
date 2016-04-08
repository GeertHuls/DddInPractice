using DddInPractice.Logic;
using DddInPractice.Logic.Atms;
using DddInPractice.Logic.SnackMachines;
using DddInPractice.UI.Atms;
using DddInPractice.UI.SnackMachines;

namespace DddInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            //var snackMachine = new SnackMachineRepository().GetById(1);
            //var viewModel = new SnackMachineViewModel(snackMachine);

            var atm = new AtmRepository().GetById(1);
            var viewModel = new AtmViewModel(atm);

            DialogService.ShowDialog(viewModel);
        }
    }
}
