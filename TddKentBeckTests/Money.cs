using System;

namespace TddKentBeckTests
{
    public class Money : IMoneyExpression
    {   
        public int Amount { get; private set; }
        
        public Money(int v, string currency)
        {
            this.Amount = v;
            Currency = currency;
        }

        public String Currency { get; set; }

        
        public override bool Equals(object obj)
        {
            var money = (Money) obj;
            return Amount == money.Amount && Currency == money.Currency;
        }

        public static Dollar Dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }
        
        public static Franc Franc(int amount)
        {
            return new Franc(amount, "CHF");
        }

        public IMoneyExpression Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }
        
        
        public IMoneyExpression Plus(IMoneyExpression addend)
        {
            return new Sum(this, addend);
        }

        public Money Reduce(Bank bank, string to)
        {
            int rate = bank.Rate(Currency, to);
            
            return new Money(Amount / rate, to);
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }
    }
}