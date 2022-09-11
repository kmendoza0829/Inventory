using Inventory.Business.Core.Repositories.Product;
using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Data.Models.Request;
using Inventory.Domain.Infrastructure.Exceptions;

namespace Inventory.Business.Core.Business
{
    public class ProductBusiness: IProductBusiness
    {
        private readonly IProductRepository _productRepository;

        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> CreateProduct(CreateProductRequest createProductRequest)
        {
            ProductManager productManager = new(createProductRequest);
            productManager.ValidateCreate();
            ProductManager exits = await _productRepository.GetByCode(createProductRequest.Code);

            if (exits != null)
            {
                throw new BadRequestException($"the code exists");
            }
            bool insert = await _productRepository.Add(productManager);
            if (insert)
                return "Product Created";
            throw new BadRequestException($"An error occurred");

        }

        public async Task<ProductManager> GetByCode(string code)
        {
            ProductManager pManager = await _productRepository.GetByCode(code);
            if (pManager != null)
                return pManager;
            throw new NotFoundException($"Not Found");
        }

        public List<ProductManager> GetUsers()
        {
            return _productRepository.GetProducts();
        }

        public async Task<string> Update(string code, int alert, int stock)
        {
            ProductManager pManager = await _productRepository.GetByCode(code);
            if (pManager == null)
                throw new NotFoundException($"Not Found");

            bool update = await _productRepository.Update(pManager.ProductId, alert, stock);
            if (update)
                return "Product Updated";
            throw new BadRequestException($"An error occurred");
        }


    }
}
