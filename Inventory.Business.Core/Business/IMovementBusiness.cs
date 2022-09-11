using Inventory.Domain.Data.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Core.Business
{
    public interface IMovementBusiness
    {
        Task<string> Create(CreateMovementRequest createMovementRequest);
    }
}
