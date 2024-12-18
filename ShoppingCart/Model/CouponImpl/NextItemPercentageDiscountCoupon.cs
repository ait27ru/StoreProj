namespace ShoppingCart.Model.CouponImpl
{
    internal class NextItemPercentageDiscountCoupon : Coupon
    {
        public decimal Percentage { get; }

        public NextItemPercentageDiscountCoupon(decimal percentage)
        {
            Percentage = percentage;
        }
    }
}
