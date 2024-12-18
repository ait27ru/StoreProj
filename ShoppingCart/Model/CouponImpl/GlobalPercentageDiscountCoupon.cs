namespace ShoppingCart.Model.CouponImpl
{
    public class GlobalPercentageDiscountCoupon : Coupon
    {
        public decimal Percentage { get; }

        public GlobalPercentageDiscountCoupon(decimal percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentException("Wrong percentage");
            }
            Percentage = percentage;
        }
    }
}
