using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Functions.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {

        public int UserId { get; set; }
    }
}
