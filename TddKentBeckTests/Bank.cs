using System;
using System.Collections.Generic;

namespace TddKentBeckTests
{
    public class Bank
    {

        public Dictionary<Pair, int> Rates { get; set; }
            = new Dictionary<Pair, int>();
        
        public int Rate(string from, string to)
        {
            if (from == to) return 1;

            return Rates[new Pair(from, to)];
        }
        
        public Money Reduce(IMoneyExpression source, String to)
        {
            return source.Reduce(this, to);
        }

        public void AddRate(string from, string to, int rate)
        {
            Rates.Add(new Pair(from, to), rate);
        }

    }
}