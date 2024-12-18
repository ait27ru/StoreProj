namespace ShoppingCart.Model
{
    public interface IPriceableItem
    {
        string Name { get; }
        decimal GetPrice();
    }
}
