using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Application.Functions.Users;
using Users.Application.Functions.Users.Commands.CreateUser;
using Users.Application.Functions.Users.Commands.DeleteUser;
using Users.Application.Functions.Users.Commands.UpdateUser;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<ActionResult<List<UserInListViewModel>>> GetAllUsers()
        {
            var listUser = await _mediator.Send(new GetUsersListQuery());
            return Ok(listUser);
        }


        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserDetailViewModel>> GetUserById(int id)
        {
            var detailViewModel = await _mediator.Send
                (new GetUserDetailListQuery() { Id = id });
            return Ok(detailViewModel);
        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<int>> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var result = await _mediator.Send(createUserCommand);
            return Ok(result.UserId);
        }

        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            await _mediator.Send(updateUserCommand);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteUserCommand = new DeleteUserCommand() { UserId = id };
            await _mediator.Send(deleteUserCommand);
            return NoContent();
        }
    }
}
