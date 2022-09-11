
using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Data.Models.Request;
using Inventory.Domain.Infrastructure.Exceptions;
using Inventory.Domain.Infrastructure.Repositories.User;
using Inventory.Domain.Infrastructure.Request;

namespace Inventory.Business.Core.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> CreateUser(CreateUserRequest createUserRequest)
        {
            UserManager userManager = new(createUserRequest);
            userManager.ValidateCreate();
            bool exitsUsername = await _userRepository.ExistsUsername(createUserRequest.Username);
            bool exitsIdentification = await _userRepository.ExistsIdentification(createUserRequest.Identificacion);
            if (exitsIdentification || exitsUsername)
            {
                throw new BadRequestException($"the identification or the user exists");
            }
            bool insert = await _userRepository.Add(userManager);
            if (insert)
                return "User Created";
            throw new BadRequestException($"An error occurred");

        }

        public async Task<UserManager> GetById(Guid id)
        {
            UserManager userManager =  await _userRepository.GetById(id);
            if (userManager != null)
                return userManager;
            throw new NotFoundException($"Not Found");
        }

        public List<UserManager> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public async Task<string> UpdateStatus(Guid id)
        {
            UserManager userManager = await _userRepository.GetById(id);
            if (userManager == null)
                throw new NotFoundException($"Not Found");

            bool update = await _userRepository.UpdateStatus(id, !userManager.Status);
            if (update)
                return "User Updated";
            throw new BadRequestException($"An error occurred");
        }

        public async Task<string> Update(UpdateUserRequest updateUserRequest)
        {
            UserManager user = await _userRepository.GetById(updateUserRequest.Id);
            if (user == null)
                throw new NotFoundException($"Not Found");

            UserManager userManager = new(updateUserRequest, user.UserId);

            bool update = await _userRepository.Update(userManager);
            if (update)
                return "User Updated";
            throw new BadRequestException($"An error occurred");
        }
    }
}
