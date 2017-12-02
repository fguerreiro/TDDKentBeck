using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Xunit;

namespace TddKentBeckTests
{
    public class UnitTest1
    {
       
        [Fact]
        public void TestMultiplication()
        {
            // test is not clean !
            Dollar five = Money.Dollar(5);

            Assert.Equal(Money.Dollar(10), five.Times(2));
            Assert.Equal(Money.Dollar(15), five.Times(3));

            //triagulation: test falsehood
            Assert.NotEqual(Money.Dollar(9), five.Times(2));
        }

        [Fact]
        public void TestFrancs()
        {
            // test is not clean !
            Franc five = Money.Franc(5);

            Assert.Equal(Money.Franc(10), five.Times(2));
            Assert.Equal(Money.Franc(15), five.Times(3));

            //triagulation: test falsehood
            Assert.NotEqual(Money.Franc(9), five.Times(2));
        }


        // Test Equality
        [Fact]
        public void TestEquality()
        {
            Assert.True(Money.Dollar(5).Equals(Money.Dollar(5)));
            Assert.False(Money.Dollar(5).Equals(Money.Dollar(6)));
            Assert.False(Money.Franc(5).Equals(Money.Dollar(5)));
        }

        [Fact]
        public void TestMultiplication2()
        {
            Money five = Money.Dollar(5);
            Assert.Equal(Money.Dollar(10), five.Times(2));
            Assert.Equal(Money.Dollar(15), five.Times(3));

        }
        
        [Fact]
        public void TestFrancMultiplication()
        {
            Money five = Money.Franc(5);
            Assert.Equal(Money.Franc(10), five.Times(2));
            Assert.Equal(Money.Franc(15), five.Times(3));

        }
        
        // We want to reduce unnecessary objects
        // strings will do for now to Represent currency
        [Fact]
        public void TestCurrency()
        {
            Assert.Equal("USD", Money.Dollar(1).Currency);
            Assert.Equal("CHF", Money.Franc(1).Currency);
        }
        
        // Triangulation


        /*
            Requirements:
            1) $5 + 10 CHF = $10 if rate is 2:1
            xx 2) $5 * 2 = 10$ (OK)
            xx 3) Make amount private
            xx 4) Dollar side effects ?
            5) Money rounding ?
            xx 6) Value Object: equals
            7) HashCode
            8) Null equals
            9) Equals obj
            xx 10) 5 CHF * 2 = 10 CHF
            xx11) Common Equals
            12) Common times 
            
            Dollar/Franc duplication
            Delete testFrancMultiplication ?
            
            xx13) Compare francs with dollars
            
            
        */

        [Fact]
        public void TestSimpleAddition()
        {
            Money five = Money.Dollar(5);
            IMoneyExpression sum = five.Plus(five);
            
            Bank bank = new Bank();
            Money reduced = bank.Reduce(sum, "USD");
            
            Assert.Equal(Money.Dollar(10), reduced);
        }
        
        [Fact]
        public void TestPlusReturnsSum()
        {
            Money five = Money.Dollar(5);
            IMoneyExpression result = five.Plus(five);

            Sum sum = (Sum) result;
            
            Assert.Equal(five, sum.Augend);
            Assert.Equal(five, sum.Addend);
        }

        [Fact]
        public void TestReduceSum()
        {
            Bank bank = new Bank();
            Money result = bank.Reduce(Money.Dollar(1), "USD");
            Assert.Equal(Money.Dollar(1), result);
        }
        
        // Create a new object that acts like Money
        // but represents the sum of two Moneys
        
        // money is the atomic form an expressoin
        // operations result in Expressions

        [Fact]
        public void TestReduceMoneyDifferentCurrency()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Money result = bank.Reduce(Money.Franc(2), "USD");
            
            Assert.Equal(Money.Dollar(1), result);
        }

        [Fact]
        public void TestArrayEquals()
        {
            Assert.Equal(new Object[]{ "abc"}, new Object[] {"abc"});
        }

        [Fact]
        public void TestIdentityRate()
        {
            Assert.Equal(1, new Bank().Rate("USD", "USD"));
        }

        [Fact]
        public void TestMixedAddition()
        {
            Money fiveBucks = Money.Dollar(5);
            Money tenFrancs = Money.Franc(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Money result = bank.Reduce(fiveBucks.Plus(tenFrancs), "USD");
            
            Assert.Equal(Money.Dollar(10), result);
        }
    }

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
