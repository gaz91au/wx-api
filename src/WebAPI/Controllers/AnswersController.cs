using Application.Common.Models;
using Application.Products.Queries;
using Application.Trolleys.Commands;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Gets user details.
        /// </summary>
        /// <returns>Returns a user object.</returns>
        /// <response code="200">Returns a json response of the requested list of group objects.</response>
        /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request.</response>
        [HttpGet]
        [Route("user")]
        [Produces(typeof(UserDto))]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _mediator.Send(new GetUserQuery()));
        }

        /// <summary>
        /// Gets a list of sorted products.
        /// </summary>
        /// <returns>A list of product objects.</returns>
        /// <response code="200">Returns a json response containing the requested group object.</response>
        /// <response code="400">The server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="404">The server can't find the requested resource.</response>
        /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request.</response>
        [HttpGet]
        [Route("sort")]
        [Produces(typeof(IList<ProductDto>))]
        [ProducesResponseType(typeof(IList<ProductDto>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> GetSortedProductListAsync(string sortOption)
        {
            return Ok(await _mediator.Send(new GetProductListQuery { SortOption = sortOption }));
        }

        /// <summary>
        /// Calculates the total of a trolley.
        /// </summary>
        /// <returns>A decimal value of the trolley total.</returns>
        /// <response code="200">Returns a json response containing the requested group object.</response>
        /// <response code="400">The server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="404">The server can't find the requested resource.</response>
        /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request.</response>
        [HttpPost]
        [Route("trolleyTotal")]
        [Produces(typeof(decimal))]
        [ProducesResponseType(typeof(decimal), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<ActionResult<decimal>> CalculateTrolleyTotal([FromBody]CalculateTrolleyCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
