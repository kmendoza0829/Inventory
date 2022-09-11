using Inventory.Business.Core.Repositories.Movement;
using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Data.Models.Request;
using Inventory.Domain.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Core.Business
{
    public class MovementBusiness: IMovementBusiness
    {
        private readonly IMovementRepository _movementRepository;

        public MovementBusiness(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public async Task<string> Create(CreateMovementRequest createMovementRequest)
        {
            MovementManager movementManager = new(createMovementRequest);
            int valueNow = await _movementRepository.SumByType(createMovementRequest.ProductId, createMovementRequest.Type);
            bool insertValid = movementManager.InsertMovement(movementManager.Type, movementManager.Quantity, valueNow);
            if (!insertValid)
            {
                throw new BadRequestException($"An error occurred");
            }
            bool insert = await _movementRepository.Add(movementManager);

            if (insert)
                return "Movement Created";
            throw new BadRequestException($"An error occurred");

        }
    }
}
