namespace TddKentBeckTests
{
    public class Money
    {
        public Money(int v)
        {
            this.Amount = v;
        }

        public int Amount { get; private set; }

        public Dollar Times(int times)
        {
            return new Dollar(Amount * times);
        }

        public override bool Equals(object obj)
        {
            return Amount == ((Dollar)obj).Amount;
        }
    }
}