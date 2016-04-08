using DddInPractice.Logic.Atms;
using DddInPractice.Logic.SharedKernel;
using DddInPractice.UI.Common;

namespace DddInPractice.UI.Atms
{
    public class AtmViewModel : ViewModel
    {
        private Atm _atm;

        public override string Caption => "ATM";
        public Money MoneyInside => _atm.MoneyInside;
        public string MoneyCharged => _atm.MoneyCharged.ToString("C2");

        public AtmViewModel(Atm atm)
        {
            _atm = atm;
        }
    }
}