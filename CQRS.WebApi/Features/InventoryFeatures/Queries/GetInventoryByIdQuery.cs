using MyCrudAppAspDotNetCore.WebApi.Domain.Models;
using MyCrudAppAspDotNetCore.WebApi.Infrastructure.Context;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace MyCrudAppAspDotNetCore.WebApi.Infrastructure.Features.InventoryFeatures.Queries
{
    public class GetInventoryByIdQuery : IRequest<Inventory>
    {
        //Command
        public Guid Id { get; set; }

        //Handler
        public class GetInventoryByIdQueryHandler : IRequestHandler<GetInventoryByIdQuery, Inventory>
        {
            private readonly IApplicationContext _context;
            public GetInventoryByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            /// <summary>
            /// handler for get inventory by Id
            /// </summary>
            /// <param name="query"></param>
            /// <param name="cancellationToken"></param>
            /// <returns>Inventory</returns>
            public async Task<Inventory> Handle(GetInventoryByIdQuery query, CancellationToken cancellationToken)
            {
                var inventory = await _context.Inventories.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                if (inventory == null) return null;
                return inventory;
            }
        }
    }
}
