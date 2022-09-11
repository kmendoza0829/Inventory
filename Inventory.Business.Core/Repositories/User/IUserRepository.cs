using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Infrastructure.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Infrastructure.Repositories.User
{
    public interface IUserRepository
    {
        Task<bool> Add(UserManager userManager);
        Task<bool> ExistsUsername(string username);
        Task<bool> ExistsIdentification(string identification);
        Task<UserManager> GetById(Guid id);
        List<UserManager> GetUsers();
        Task<bool> UpdateStatus(Guid id, bool status);
        Task<bool> Update(UserManager userManager);
    }
}
