namespace ShoppingCart.Model
{
    public class Item : ICartElement, IPriceableItem
    {
        public string Name { get; }
        private decimal _price;

        public Item(string name, decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Negative price");
            }
            Name = name;
            _price = price;
        }

        public decimal GetPrice()
        {
            return _price;
        }
    }
}
