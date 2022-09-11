using Inventory.Domain.Data.Models.Request;
using Inventory.Domain.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Data.Models.Implementation
{
    public class ProductManager
    {

        public Guid ProductId { get; private set; }
        public string? Code { get; private set; }
        public int AlertMin { get; private set; }
        public int Stock { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime ModificationUpdate { get; private set; }

        public ProductManager()
        {
        }
        public ProductManager(CreateProductRequest createProductRequest)
        {
            ProductId = Guid.NewGuid();
            Code = createProductRequest.Code;
            AlertMin = createProductRequest.AlertMin;
            Stock = createProductRequest.Stock;
            UserId = createProductRequest.UserId;
            CreationTime = DateTime.Now;
            ModificationUpdate = DateTime.Now;
        }

        public void ValidateCreate()
        {
            if (string.IsNullOrEmpty(Code))
                throw new BadRequestException($"The Code field is mandatory");
            if (AlertMin < 0)
                throw new BadRequestException($"The AlertMin field is mandatory");
            if (Stock < 0)
                throw new BadRequestException($"The Stock field is mandatory");

        }

    }
}
