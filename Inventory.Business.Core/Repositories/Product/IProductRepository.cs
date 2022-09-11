using Inventory.Domain.Data.Models.Implementation;

namespace Inventory.Business.Core.Repositories.Product
{
    public interface IProductRepository
    {
        Task<bool> Add(ProductManager productManager);
        Task<ProductManager> GetByCode(string code);
        List<ProductManager> GetProducts();
        Task<bool> Update(Guid id, int alert, int Stock);
    }
}
