namespace Logic
{
  public class OrderItem {

    public int OrderId { get; set; }

    public int OrderItemId { get; set; }

    public Product Product { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

  }
    
}