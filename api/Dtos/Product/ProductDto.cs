namespace api.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockNow { get; set; }

        public int ProductCategoryId { get; set; }
        public string? ProductCategoryName { get; set; }

        public int ProductUnitId { get; set; }
        public string? ProductUnitName { get; set; }

        public required string Supplier { get; set; }

        public string? Color { get; set; }

        public string? PhotoUrl { get; set; }
        
        public bool IsActive { get; set; }
    }
}
