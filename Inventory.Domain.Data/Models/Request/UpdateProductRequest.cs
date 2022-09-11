using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Data.Models.Request
{
    public class UpdateProductRequest
    {
        public string? Code { get; set; }
        public int AlertMin { get; set; }
        public int Stock { get; set; }
    }
}
