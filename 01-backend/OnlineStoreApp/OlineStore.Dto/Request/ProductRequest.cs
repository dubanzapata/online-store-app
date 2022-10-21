﻿namespace OlineStore.Dto.Request
{
    public class ProductRequest
    {
        
        public int IdProvider { get; set; }
        public string? NameProduct { get; set; }
        public decimal? Price { get; set; }
        public int? Amount { get; set; }
        public DateTime? DateOfExpery { get; set; }
    }
}
