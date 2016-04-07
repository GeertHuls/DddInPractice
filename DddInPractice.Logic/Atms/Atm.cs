using DddInPractice.Logic.Common;
using DddInPractice.Logic.SharedKernel;
using static DddInPractice.Logic.SharedKernel.Money;

namespace DddInPractice.Logic.Atms
{
    public class Atm : AggregateRoot
    {
        private const decimal CommissionRate = 0.01m;

        public virtual Money MoneyInside { get; protected set; } = None;
        public virtual decimal MoneyCharged { get; protected set; }

        public virtual void TakeMoney(decimal amount)
        {
            var output = MoneyInside.Allocate(amount);
            MoneyInside -= output;

            var amountWithCommission = amount + amount * CommissionRate;
            MoneyCharged += amountWithCommission;
        }

        public void LoadMoney(Money money)
        {
            MoneyInside += money;
        }
    }
}