namespace Inventory.Domain.Data.Models.Request
{
    public class CreateMovementRequest
    {
        public Guid ProductId { get; set; }
        public int Type { get; set; }
        public int Quantity { get; set; }
        public Guid UserId { get; set; }
        public string? Observation { get; set; }
    }
}
