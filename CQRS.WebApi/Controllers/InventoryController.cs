using MyCrudAppAspDotNetCore.WebApi.Application.Features.InventoryFeatures.Commands;
using MyCrudAppAspDotNetCore.WebApi.Application.Features.InventoryFeatures.Queries;
using MyCrudAppAspDotNetCore.WebApi.Infrastructure.Features.InventoryFeatures.Queries;
using MyCrudAppAspDotNetCore.WebApi.Features.InventoryFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using MyCrudAppAspDotNetCore.WebApi.Domain.Models;
using System.Collections.Generic;

namespace MyCrudAppAspDotNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IMediator _mediator;
        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        /// <summary>
        /// Creates a New Inventory.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInventoryCmd command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Gets all Inventorys.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Inventory>> GetAll()
        {
            var result = await _mediator.Send(new GetInventoryListQuery());
            return result;
        }

        /// <summary>
        /// Gets Inventory Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetInventoryByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deletes Inventory Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteInventoryByIdCmd { Id = id }));
        }

        /// <summary>
        /// Updates the Inventory Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInventoryCmd command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }
    }
}