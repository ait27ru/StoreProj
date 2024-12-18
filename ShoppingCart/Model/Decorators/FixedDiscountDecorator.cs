namespace ShoppingCart.Model.Decorators
{
    public class FixedDiscountDecorator : ItemDecorator
    {
        private decimal _discount;

        public FixedDiscountDecorator(IPriceableItem inner, decimal discount)
            : base(inner)
        {
            if (discount < 0)
            {
                throw new ArgumentException("Negative discount");
            }
            _discount = discount;
        }

        public override decimal GetPrice()
        {
            var price = _inner.GetPrice() - _discount;
            return price < 0 ? 0 : price;
        }
    }
}
