namespace InstrumentTrade.WebUI.Areas.Customer.Models
{
    public class OrderDetailViewModel
    {
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<OrderItemViewModel> Items { get; set; }
    }
}
