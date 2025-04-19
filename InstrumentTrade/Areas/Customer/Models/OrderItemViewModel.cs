namespace InstrumentTrade.WebUI.Areas.Customer.Models
{
    public class OrderItemViewModel
    {
        public string ProductName { get; set; }

        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } // birim fiyat
        public decimal Total => Quantity * Price;
    }
}
