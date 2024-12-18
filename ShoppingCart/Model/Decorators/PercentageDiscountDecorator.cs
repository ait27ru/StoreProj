namespace ShoppingCart.Model.Decorators
{
    public class PercentageDiscountDecorator : ItemDecorator
    {
        private readonly decimal _percentage;

        public PercentageDiscountDecorator(IPriceableItem inner, decimal percentage)
            : base(inner)
        {
            _percentage = percentage;
        }

        public override decimal GetPrice()
        {
            decimal price = _inner.GetPrice();
            return price * (100 - _percentage) / 100;
        }
    }
}
