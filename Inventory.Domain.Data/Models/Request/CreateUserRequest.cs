using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Infrastructure.Request
{
    public class CreateUserRequest
    {
        public string? Identificacion { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int Type { get; set; }
    }
}
