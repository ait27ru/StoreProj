namespace ShoppingCart.Model
{
    public abstract class ItemDecorator : IPriceableItem
    {
        protected IPriceableItem _inner;

        protected ItemDecorator(IPriceableItem inner)
        {
            _inner = inner;
        }

        public string Name => _inner.Name;

        public abstract decimal GetPrice();
    }
}
