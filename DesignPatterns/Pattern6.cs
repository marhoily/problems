using FluentAssertions;
using Xunit;

namespace DesignPatters
{
    public sealed class Pattern6
    {
        interface IProduct { decimal Cost { get; } }

        class Product : IProduct
        {
            public decimal Cost { get; }
            public Product(decimal cost) { Cost = cost; }
        }
        class Delivery : IProduct
        {
            private readonly IProduct _baseProduct;
            private readonly decimal _value;
            public Delivery(IProduct baseProduct, decimal value)
            {
                _baseProduct = baseProduct;
                _value = value;
            }
            public decimal Cost => _baseProduct.Cost + _value;

        }
        class Tax : IProduct
        {
            private readonly IProduct _baseProduct;
            private readonly decimal _value;
            public Tax(IProduct baseProduct, decimal value)
            {
                _baseProduct = baseProduct;
                _value = value;
            }

            public decimal Cost => _baseProduct.Cost * _value;
        }

        [Fact]
        public void Test()
        {
            new Tax(new Delivery(new Product(5), 3), 1.2m)
                .Cost.Should().Be(9.6m);
        }
    }
}
 