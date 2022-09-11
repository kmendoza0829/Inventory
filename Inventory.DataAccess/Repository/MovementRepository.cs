using Dapper;
using Inventory.Business.Core.Repositories.Movement;
using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Infrastructure.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAccess.Repository
{
    public class MovementRepository: IMovementRepository
    {
        private readonly IOptions<AppSettingsModel> settings;

        public MovementRepository(IOptions<AppSettingsModel> settings)
        {
            this.settings = settings;
        }

        public async Task<bool> Add(MovementManager movementManager)
        {
            using IDbConnection db = new SqlConnection(settings.Value.DefaultConnection);
            string insertUserSQL = "INSERT INTO Movements(MovementId,ProductId,Type,Quantity,UserId,DateCreation,Observation) " +
                "VALUES (@MovementId, @ProductId, @Type, @Quantity, @UserId, @DateCreation,@Observation)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@MovementId", movementManager.MovementId);
            dynamicParameters.Add("@ProductId", movementManager.ProductId);
            dynamicParameters.Add("@Type", movementManager.Type);
            dynamicParameters.Add("@Quantity", movementManager.Quantity);
            dynamicParameters.Add("@UserId", movementManager.UserId);
            dynamicParameters.Add("@DateCreation", movementManager.DateCreation);
            dynamicParameters.Add("@Observation", movementManager.Observation);            
            int rowsInserted = await db.ExecuteAsync(insertUserSQL, dynamicParameters);
            if (rowsInserted > 0)
                return true;
            return false;
        }

        public async Task<int> SumByType(Guid productId, int type)
        {
            using IDbConnection db = new SqlConnection(settings.Value.DefaultConnection);
            string usernameSQL = @"SELECT SUM(Quantity) AS suma FROM Movements WHERE ProductId = @ProductId AND Type = @Type";
            int total = await db.QueryFirstOrDefaultAsync<int>(usernameSQL, new { ProductId = productId, Type = type  });
            
            return total;
        }

    }
}
