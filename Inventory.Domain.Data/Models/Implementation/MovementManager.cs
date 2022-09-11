using Inventory.Domain.Data.Models.Request;
using Inventory.Domain.Infrastructure.Exceptions;

namespace Inventory.Domain.Data.Models.Implementation
{
    public class MovementManager
    {
        public Guid MovementId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Type { get; private set; }
        public int Quantity { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime DateCreation { get; private set; }
        public string? Observation { get; private set; }

        public MovementManager()
        {
        }

        public MovementManager(CreateMovementRequest createMovementRequest)
        {
            MovementId = Guid.NewGuid();
            ProductId = createMovementRequest.ProductId;
            Type = createMovementRequest.Type;
            Quantity = createMovementRequest.Quantity;
            UserId = createMovementRequest.UserId;
            DateCreation = DateTime.Now;
            Observation = createMovementRequest.Observation;
        }

        public bool InsertMovement(int type, int valueInsert, int valueNow)
        {
            if (type == 1 && valueInsert <= 0)
            { //In
                throw new BadRequestException($"The value invalid");
            }

            if (type == 2 && valueInsert > valueNow)
            {
                //out
                throw new BadRequestException($"No Stock");
            }

            return true;

        }
    }
}
