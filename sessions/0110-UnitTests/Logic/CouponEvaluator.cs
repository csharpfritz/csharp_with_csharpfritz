using System;

namespace Logic
{
  public class CouponEvaluator {

    public void ApplyCoupon(Order order) {

      // Save 10% with the SAVE10 coupon code
      if (order.CouponCode == "SAVE10") {
        order.CouponSavings = order.TotalCost * 0.1m;
      }

    }

  }
    
}