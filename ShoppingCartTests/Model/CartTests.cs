using ShoppingCart.Model.CouponImpl;
using Xunit;
using Assert = Xunit.Assert;

namespace ShoppingCart.Model.Tests
{
    public class CartTests
    {
        private readonly Cart _sut;

        public CartTests()
        {
            _sut = new Cart();
        }

        public class CalcTotal : CartTests
        {
            [Fact()]
            public void ShouldReturnZero_WhenCartIsEmpty()
            {
                // act
                var res = _sut.CalcTotal();

                // assert
                Assert.Equal(0, res);
            }

            [Fact()]
            public void ShouldReturnItemsTotal_WhenNoDiscounts()
            {
                // arrange
                _sut.Add(new Item("Apple", 1m));
                _sut.Add(new Item("Orange", 2m));

                // act
                var res = _sut.CalcTotal();

                // assert
                Assert.Equal(3, res);
            }

            [Fact()]
            public void ShouldReturnDiscountedTotal_WhenQuantityBasedDiscountApplied()
            {
                // arrange
                _sut.Add(new Item("Apple", 1m));
                _sut.Add(new Item("Apple", 1m));
                _sut.Add(new Item("Orange", 2m));
                _sut.Add(new Item("Orange", 2m));
                _sut.Add(new QuantityBasedDiscountCoupon("Apple", 2, 50));

                // act
                var res = _sut.CalcTotal();

                // assert
                Assert.Equal(5, res);
            }
        }
    }
}