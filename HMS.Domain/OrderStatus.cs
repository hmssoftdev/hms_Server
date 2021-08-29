namespace HMS.Domain
{
    public class OrderStatus : BaseEntity
    {
        public int OrderId { get; set; }
        public int Status { get; set; }
    }
}
