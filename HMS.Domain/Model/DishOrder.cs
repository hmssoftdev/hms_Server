namespace HMS.Domain.Model
{
    public class DishOrder
    {
        public int Id { get; set; }
        public float DeliveryTotal { get; set; }
        public float GrossTotal { get; set; }
        public int ItemCount { get; set; }
        public float ItemTotal { get; set; }
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public int DeliveryOptionId { get; set; }
        public int PaymentMode { get; set; }
        public string UserName { get; set; }
        public string UserMobileNumber { get; set; }
        public int Status { get; set; }
        public float DiscountInPercent { get; set; }
        public float DiscountInRupees { get; set; }
        public float AdditionalAmount { get; set; }
        public int GstTotal { get; set; }

    }
}
