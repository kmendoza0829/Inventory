using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAccess.Entities
{
    public class User
    {
        public Guid? Id { get; set; }
        public string? Identificacion { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int Type { get; set; }
        public bool Status { get;  set; }
        public DateTime DateCreation { get;  set; }
    }
}
