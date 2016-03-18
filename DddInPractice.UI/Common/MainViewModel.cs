using DddInPractice.Logic;

namespace DddInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            var viewModel = new SnackMachineViewModel(new SnackMachine());
            DialogService.ShowDialog(viewModel);
        }
    }
}
