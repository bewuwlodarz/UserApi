using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Functions.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse> 
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public int UserAddressId { get; set; } 
        public int UserProfileSettingId { get; set; }


    }
}
