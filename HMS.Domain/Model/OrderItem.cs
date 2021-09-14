namespace HMS.Domain.Model
{
    public class OrderItem 
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public float Price { get; set; }
        public float GstCompliance { get; set; }
        public float GstPrice { get; set; }
        public int OrderID { get; set; }
        public string DishName { get; set; }
    }
}
