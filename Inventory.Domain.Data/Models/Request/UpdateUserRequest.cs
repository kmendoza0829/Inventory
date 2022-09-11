using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Data.Models.Request
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string? Identificacion { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
