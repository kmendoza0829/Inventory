namespace Inventory.DataAccess.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string? Code { get; set; }
        public int AlertMin { get; set; }
        public int Stock { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationUpdate { get; set; }
    }
}
