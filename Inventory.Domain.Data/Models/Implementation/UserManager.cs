
using Inventory.Domain.Data.Models.Request;
using Inventory.Domain.Infrastructure.Exceptions;
using Inventory.Domain.Infrastructure.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Data.Models.Implementation
{
    public class UserManager
    {

        public Guid UserId { get; private set; }
        public string? Identification { get; private set; }
        public string? Name { get; private set; }
        public string? Username { get; private set; }
        public string? Password { get; private set; }
        public int Type { get; private set; }
        public bool Status { get; private set; }
        public DateTime DateCreation { get; private set; }

        public UserManager()
        {
        }

        public UserManager(CreateUserRequest createUserRequest)
        {
            UserId = Guid.NewGuid();
            Identification = createUserRequest.Identificacion;
            Type = createUserRequest.Type;
            Name = createUserRequest.Name;
            Username = createUserRequest.Username;
            Password = BCrypt.Net.BCrypt.HashPassword(createUserRequest.Password); 
            //bool verified = BCrypt.Net.BCrypt.Verify("Pa$$w0rd", passwordHash);
            Status = true;
            DateCreation = DateTime.Now;
        }

        public UserManager(UpdateUserRequest createUserRequest, Guid id)
        {
            UserId = id;
            Identification = createUserRequest.Identificacion;
            Name = createUserRequest.Name;
            Password = BCrypt.Net.BCrypt.HashPassword(createUserRequest.Password);
        }

        public void ValidateCreate()
        {
            if(string.IsNullOrEmpty(Identification))
                throw new BadRequestException($"The identification field is mandatory");
            if (string.IsNullOrEmpty(Name))
                throw new BadRequestException($"The Name field is mandatory");
            if (string.IsNullOrEmpty(Username))
                throw new BadRequestException($"The Username field is mandatory");
            if (string.IsNullOrEmpty(Password))
                throw new BadRequestException($"The Password field is mandatory");
            
        }


    }
}
