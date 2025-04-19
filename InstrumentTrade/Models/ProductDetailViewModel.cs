﻿using InstrumenShop.EntityLayer.Entities;

namespace InstrumentTrade.WebUI.Models
{
    public class ProductDetailViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool InStock => Stock > 0;


        
    }
}
