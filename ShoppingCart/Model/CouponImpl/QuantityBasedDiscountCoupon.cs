namespace ShoppingCart.Model.CouponImpl
{
    public class QuantityBasedDiscountCoupon : Coupon
    {
        public string TargetItemName { get; }
        public int Threshold { get; }
        public decimal DiscountPercentage { get; }

        public QuantityBasedDiscountCoupon(string targetItemName, int threshold, decimal discountPercentage)
        {
            if (string.IsNullOrWhiteSpace(targetItemName))
                throw new ArgumentNullException(nameof(targetItemName));

            TargetItemName = targetItemName;
            Threshold = threshold;
            DiscountPercentage = discountPercentage;
        }
    }
}
