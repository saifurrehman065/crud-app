using MyCrudAppAspDotNetCore.WebApi.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyCrudAppAspDotNetCore.WebApi.Features.InventoryFeatures.Commands
{
    public class DeleteInventoryByIdCmd : IRequest<Guid>
    {
        //commmand 
        public Guid Id { get; set; }


        /// <summary>
        /// Inventory Delete handler
        /// </summary>
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteInventoryByIdCmd, Guid>
        {
            private readonly IApplicationContext _context;
            public DeleteProductByIdCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            /// <summary>
            /// handler for delete inventory
            /// </summary>
            /// <param name="command"></param>
            /// <param name="cancellationToken"></param>
            /// <returns>Guid</returns>
            public async Task<Guid> Handle(DeleteInventoryByIdCmd command, CancellationToken cancellationToken)
            {
                var inventory = await _context.Inventories.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (inventory == null) return default;
                _context.Inventories.Remove(inventory);
                await _context.SaveChangesAsync();
                return inventory.Id;
            }
        }
    }
}
