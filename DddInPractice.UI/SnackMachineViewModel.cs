using DddInPractice.Logic;
using DddInPractice.UI.Common;

namespace DddInPractice.UI
{
    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachine _snackMachine;
        public override string Caption => "Snack machine";

        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _snackMachine = snackMachine;
        }
    }
}
