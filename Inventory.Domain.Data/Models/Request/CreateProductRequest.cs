namespace Inventory.Domain.Data.Models.Request
{
    public class CreateProductRequest
    {
        public string? Code { get; set; }
        public int AlertMin { get; set; }
        public int Stock { get; set; }
        public Guid UserId { get; set; }
    }
}
