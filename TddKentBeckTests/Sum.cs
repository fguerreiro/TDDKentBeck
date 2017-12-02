using System;

namespace TddKentBeckTests
{
    public class Sum : IMoneyExpression
    {
        public IMoneyExpression Augend { get; set; }
        public IMoneyExpression Addend { get; set; }

        public Sum(IMoneyExpression augend, IMoneyExpression addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(Bank bank, String to)
        {
            int amount =
                Augend.Reduce(bank, to).Amount
                + Addend.Reduce(bank, to).Amount;
            
            return new Money(amount, to);
        }
       
        public IMoneyExpression Plus(IMoneyExpression addend)
        {
            return new Sum(this, addend);
        }
    }
}