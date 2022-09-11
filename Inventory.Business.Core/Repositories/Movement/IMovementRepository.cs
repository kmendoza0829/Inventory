using Inventory.Domain.Data.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Core.Repositories.Movement
{
    public interface IMovementRepository
    {
        Task<bool> Add(MovementManager movementManager);
        Task<int> SumByType(Guid productId, int type);
    }
}
