using ShoppingCart.Model.CouponImpl;
using ShoppingCart.Model.Decorators;

namespace ShoppingCart.Model
{
    public class Cart
    {
        private List<ICartElement> _elements = new List<ICartElement>();

        public void Add(ICartElement element)
        {
            _elements.Add(element);
        }

        public decimal CalcTotal()
        {
            List<IPriceableItem> items = new List<IPriceableItem>();
            List<int> itemIndexes = new List<int>();

            var total = 0m;

            for (int i = 0; i < _elements.Count; i++)
            {
                if (_elements[i] is IPriceableItem pItem)
                {
                    items.Add(pItem);
                }
            }

            var quantityDiscounts = _elements.OfType<QuantityBasedDiscountCoupon>().ToList();

            foreach (var qc in quantityDiscounts)
            {
                int count = 0;

                for (int i = 0; i < _elements.Count; i++)
                {
                    if (_elements[i] is IPriceableItem pit &&
                        string.Equals(pit.Name, qc.TargetItemName, StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                    }
                }

                if (count >= qc.Threshold)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (string.Equals(items[i].Name, qc.TargetItemName, StringComparison.OrdinalIgnoreCase))
                        {
                            items[i] = new PercentageDiscountDecorator(items[i], qc.DiscountPercentage);
                        }
                    }
                }
            }

            foreach (var item in items)
            {
                total += item.GetPrice();
            }

            return Math.Round(total, 2);
        }
    }
}