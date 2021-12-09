using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Functions.Users
{
    public class GetUserDetailListQuery : IRequest<UserDetailViewModel>
    {
        public int Id { get; set; }
    }
}
