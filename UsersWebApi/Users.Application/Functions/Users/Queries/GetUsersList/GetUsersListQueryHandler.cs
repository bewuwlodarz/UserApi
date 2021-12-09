using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Users.Application.Contracts.Persistance;
using Users.Domain.Entities;

namespace Users.Application.Functions.Users
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UserInListViewModel>>
    {

        private readonly IAsyncRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<List<UserInListViewModel>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var all = await _userRepository.GetAllAsync();
            //var allOrdered = all.OrderBy(x => x.CreatedOn);

            return _mapper.Map<List<UserInListViewModel>>(all);

        }
    }
}
