using System;

namespace TddKentBeckTests
{
    public class Pair
    {
        public String To { get; set; }
        public String From { get; set; }

        public Pair(string from, string to)
        {
            From = @from;
            To = to;
        }

        public override bool Equals(object other)
        {
            return From == ((Pair)other).From && To == ((Pair)other).To;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}