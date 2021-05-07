using MyCrudAppAspDotNetCore.WebApi.Domain.Models;
using MyCrudAppAspDotNetCore.WebApi.Infrastructure.Context;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyCrudAppAspDotNetCore.WebApi.Application.Features.InventoryFeatures.Commands
{
    public class CreateInventoryCmd : IRequest<Guid>
    {
        //commands
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// handlers class
        /// </summary>
        public class CreateProductCommandHandler : IRequestHandler<CreateInventoryCmd, Guid>
        {
            private readonly IApplicationContext _context;
            public CreateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            /// <summary>
            /// handler for create inventory
            /// </summary>
            /// <param name="command"></param>
            /// <param name="cancellationToken"></param>
            /// <returns>Guid</returns>
            public async Task<Guid> Handle(CreateInventoryCmd command, CancellationToken cancellationToken)
            {
                var inventory = new Inventory();

                inventory.Id = Guid.NewGuid();
                inventory.Name = command.Name;
                inventory.Price = command.Price;
                inventory.Description = command.Description;
                inventory.CreatedOn = DateTime.UtcNow;
                _context.Inventories.Add(inventory);
                await _context.SaveChangesAsync();

                return inventory.Id;
            }
        }
    }
}
