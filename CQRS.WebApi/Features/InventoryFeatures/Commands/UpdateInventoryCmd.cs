using MyCrudAppAspDotNetCore.WebApi.Infrastructure.Context;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyCrudAppAspDotNetCore.WebApi.Features.InventoryFeatures.Commands
{
    public class UpdateInventoryCmd : IRequest<Guid>
    {
        //Commands
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //Handler class
        public class UpdateProductCommandHandler : IRequestHandler<UpdateInventoryCmd, Guid>
        {
            private readonly IApplicationContext _context;
            public UpdateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            /// <summary>
            /// handler for update inventory
            /// </summary>
            /// <param name="command"></param>
            /// <param name="cancellationToken"></param>
            /// <returns>Guid</returns>
            public async Task<Guid> Handle(UpdateInventoryCmd command, CancellationToken cancellationToken)
            {
                var inventory = await _context.Inventories.Where(a => a.Id == command.Id)
                    .FirstOrDefaultAsync(cancellationToken);

                if (inventory == null)
                {
                    return default;
                }
                else
                {
                    inventory.Name = command.Name;
                    inventory.Price = command.Price;
                    inventory.Description = command.Description;
                    await _context.SaveChangesAsync();
                    return inventory.Id;
                }
            }
        }
    }
}
