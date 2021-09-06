namespace HMS.Domain
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public float Price { get; set; }
        public float GstCompliance { get; set; }
        public float GstPrice { get; set; }
        public int OrderID { get; set; }
        public bool IsFull { get; set; }
    }
}
