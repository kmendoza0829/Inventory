using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Data.Models.Request;

namespace Inventory.Business.Core.Business
{
    public interface IProductBusiness
    {
        Task<string> CreateProduct(CreateProductRequest createProductRequest);
        Task<ProductManager> GetByCode(string code);
        List<ProductManager> GetUsers();
        Task<string> Update(string code, int alert, int stock);
    }
}
