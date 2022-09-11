using Dapper;
using Inventory.Business.Core.Repositories.Product;
using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Infrastructure.Models;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Inventory.DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IOptions<AppSettingsModel> settings;

        public ProductRepository(IOptions<AppSettingsModel> settings)
        {
            this.settings = settings;
        }

        public async Task<bool> Add(ProductManager productManager)
        {
            using IDbConnection db = new SqlConnection(settings.Value.DefaultConnection);
            string insertUserSQL = "INSERT INTO Products(ProductId,Code,AlertMin,Stock,UserId,CreationTime,ModificationTime) " +
                "VALUES (@ProductId, @Code, @AlertMin, @Stock, @UserId, @CreationTime,@ModificationTime)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@ProductId", productManager.ProductId);
            dynamicParameters.Add("@Code", productManager.Code);
            dynamicParameters.Add("@AlertMin", productManager.AlertMin);
            dynamicParameters.Add("@Stock", productManager.Stock);
            dynamicParameters.Add("@UserId", productManager.UserId);
            dynamicParameters.Add("@CreationTime", productManager.CreationTime);
            dynamicParameters.Add("@ModificationTime", productManager.ModificationUpdate);
            int rowsInserted = await db.ExecuteAsync(insertUserSQL, dynamicParameters);
            if (rowsInserted > 0)
                return true;
            return false;
        }

        public async Task<ProductManager> GetByCode(string code)
        {
            using IDbConnection db = new SqlConnection(settings.Value.DefaultConnection);
            string productSQL = @"SELECT * FROM Products WHERE Code = @Code";
            ProductManager product = await db.QueryFirstOrDefaultAsync<ProductManager>(productSQL, new { Code = code });
            return product;
        }

        public List<ProductManager> GetProducts()
        {
            List<ProductManager> users = new();
            using (IDbConnection db = new SqlConnection(settings.Value.DefaultConnection))
            {
                string usernameSQL = @"SELECT * FROM Products ";
                using (var reader = db.ExecuteReader(usernameSQL))
                {
                    var parser = reader.GetRowParser<ProductManager>();
                    while (reader.Read())
                    {
                        ProductManager userParser = parser(reader);
                        users.Add(userParser);
                    }
                }
            };
            return users;
        }

        public async Task<bool> Update(Guid id, int alert, int Stock)
        {

            using IDbConnection db = new SqlConnection(settings.Value.DefaultConnection);
            string updateUserSQL = "UPDATE Products SET AlertMin = @AlertMin,Stock = @Stock WHERE ProductId = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@AlertMin", alert);
            dynamicParameters.Add("@Stock", Stock);
            dynamicParameters.Add("@Id", id);
            int rowsInserted = await db.ExecuteAsync(updateUserSQL, dynamicParameters);
            if (rowsInserted > 0)
                return true;
            return false;
        }
    }
}
