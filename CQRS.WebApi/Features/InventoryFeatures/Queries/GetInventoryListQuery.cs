using MyCrudAppAspDotNetCore.WebApi.Domain.Models;
using MyCrudAppAspDotNetCore.WebApi.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyCrudAppAspDotNetCore.WebApi.Application.Features.InventoryFeatures.Queries
{
    public class GetInventoryListQuery : IRequest<IEnumerable<Inventory>>
    {

        public class GetInventoryListQueryHandler : IRequestHandler<GetInventoryListQuery,IEnumerable<Inventory>>
        {
            private readonly IApplicationContext _context;
            public GetInventoryListQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            /// <summary>
            /// Get Inventory List
            /// </summary>
            /// <param name="query"></param>
            /// <param name="cancellationToken"></param>
            /// <returns>List of Inventories</returns>
            public async Task<IEnumerable<Inventory>> Handle(GetInventoryListQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Inventories.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
