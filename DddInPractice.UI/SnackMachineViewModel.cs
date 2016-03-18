using System.Globalization;
using DddInPractice.Logic;
using DddInPractice.UI.Common;

namespace DddInPractice.UI
{
    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachine _snackMachine;
        public override string Caption => "Snack machine";
        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.Amount.ToString(CultureInfo.InvariantCulture);

        public Command InsertCentCommand { get; private set; }

        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _snackMachine = snackMachine;
            InsertCentCommand = new Command((InsertCent));
        }

        private void InsertCent()
        {
            _snackMachine.InsertMoney(Money.Cent);
            Notify("MoneyInTransaction");
        }
    }
}
