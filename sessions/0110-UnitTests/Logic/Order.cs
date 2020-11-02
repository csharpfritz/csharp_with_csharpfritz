using System.Collections.Generic;

namespace Logic
{

  public class Order {

    public int OrderId { get; set; }

    public string CustomerName { get; set; }

    public List<OrderItem> Items { get; set; }

    public string CouponCode { get; set; }

    public decimal CouponSavings { get; set; } = 0m;

    public decimal TotalCost { get; set; }

  }
    
}