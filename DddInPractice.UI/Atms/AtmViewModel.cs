using DddInPractice.Logic.Atms;
using DddInPractice.Logic.SharedKernel;
using DddInPractice.UI.Common;

namespace DddInPractice.UI.Atms
{
    public class AtmViewModel : ViewModel
    {
        private readonly PaymentGateway _paymentGateway;
        private readonly Atm _atm;
        private readonly AtmRepository _repository;

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                Notify();
            }
        }

        public override string Caption => "ATM";
        public Money MoneyInside => _atm.MoneyInside;
        public string MoneyCharged => _atm.MoneyCharged.ToString("C2");
        public Command<decimal> TakeMoneyCommand { get; private set; }

        public AtmViewModel(Atm atm)
        {
            _atm = atm;
            _repository = new AtmRepository();
            _paymentGateway = new PaymentGateway();

            TakeMoneyCommand = new Command<decimal>(x => x > 0, TakeMoney);
        }

        private void TakeMoney(decimal amount)
        {
            var error = _atm.CanTakeMoney(amount);
            if (error != string.Empty)
            {
                NotifyClient(error);
                return;
            }

            var amountWithCommision = _atm.CalculateAmountWithCommission(amount);
            _paymentGateway.ChargePayment(amountWithCommision);
            _atm.TakeMoney(amount);
            _repository.Save(_atm);

            NotifyClient("You have taken " + amount.ToString("C2"));
        }

        private void NotifyClient(string message)
        {
            Message = message;
            Notify(nameof(MoneyInside));
            Notify(nameof(MoneyCharged));
        }
    }
}