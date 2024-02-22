namespace WebApi2.Models
{
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public int Id { get; set; }
        public string? UserName { get; set; }
        public decimal PrecoFrete { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
