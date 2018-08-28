using System;
using System.Collections.Generic;
using FakeItEasy;
using Xunit;

namespace DesignPatters
{
    public sealed class Pattern10
    {
        public interface IInvestor
        {
            void Update(Stock stock);
        }
        public sealed class Stock
        {
            public string Symbol { get; }
            public decimal Price { get; private set; }
            private readonly List<IInvestor>
                _investors = new List<IInvestor>();

            public Stock(string symbol, decimal price)
            {
                Symbol = symbol;
                Price = price;
            }

            public void Attach(IInvestor investor) => _investors.Add(investor);
            public void Detach(IInvestor investor) => _investors.Remove(investor);

            public void ChangePrice(decimal value)
            {
                Price = value;
                foreach (var investor in _investors)
                    investor.Update(this);
            }
        }

        [Fact]
        public void Test()
        {
            var nasdaq = new Stock("USTEC", 4330);
            var sAndP500 = new Stock("US500", 2043);
            var john = A.Fake<IInvestor>();
            nasdaq.Attach(john);
            sAndP500.Attach(john);
            nasdaq.ChangePrice(4335);
            A.CallTo(() => john.Update(nasdaq))
                .MustHaveHappened();
        }
    }
}
