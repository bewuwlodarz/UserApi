using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Application.Functions.Addresses.Commands.CreateAddress;
using Users.Application.Functions.Addresses.Queries.GetAddressesList;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllAddresses")]
        public async Task<ActionResult<List<AddressInListViewModel>>> GetAllAddresses()
        {
            var listUser = await _mediator.Send(new GetAddressesListQuery());
            return Ok(listUser);
        }


        [HttpPost(Name = "AddAddress")]
        public async Task<ActionResult<int>> Create([FromBody] CreateAddressCommand createUserCommand)
        {
            var result = await _mediator.Send(createUserCommand);
            return Ok(result.AddressId);
        }
    }
}
