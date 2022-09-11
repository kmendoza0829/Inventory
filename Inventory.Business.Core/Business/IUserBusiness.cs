using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Data.Models.Request;
using Inventory.Domain.Infrastructure.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Core.Business
{
    public interface IUserBusiness
    {
        Task<string> CreateUser(CreateUserRequest createUserRequest);
        Task<UserManager> GetById(Guid id);
        List<UserManager> GetUsers();
        Task<string> UpdateStatus(Guid id);
        Task<string> Update(UpdateUserRequest updateUserRequest);
    }
}
