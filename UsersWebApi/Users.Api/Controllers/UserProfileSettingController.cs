using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Application.Functions.UserProfileSettings.Commands.CreateUserProfileSetting;
using Users.Application.Functions.UserProfileSettings.Queries.GetUserProfileSetting;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileSettingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserProfileSettingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllUserProfileSettings")]
        public async Task<ActionResult<List<UserProfileSettingListViewModel>>> GetAllUserProfileSettings()
        {
            var listUser = await _mediator.Send(new GetUserProfileSettingQuery());
            return Ok(listUser);
        }


        [HttpPost(Name = "AddUserProfileSetting")]
        public async Task<ActionResult<int>> Create([FromBody] CreateUserSettingProfileCommand createUserCommand)
        {
            var result = await _mediator.Send(createUserCommand);
            return Ok(result.UserProfileSettingId);
        }
    }
}
