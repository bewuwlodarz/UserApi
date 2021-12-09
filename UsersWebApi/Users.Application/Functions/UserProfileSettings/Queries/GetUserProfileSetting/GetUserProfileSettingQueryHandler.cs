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

namespace Users.Application.Functions.UserProfileSettings.Queries.GetUserProfileSetting
{
    public class GetUserProfileSettingQueryHandler : IRequestHandler<GetUserProfileSettingQuery, List<UserProfileSettingListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<UserProfileSetting> _userProfileSettingRepository;
        public GetUserProfileSettingQueryHandler(IMapper mapper, IAsyncRepository<UserProfileSetting> userProfileSettingRepository)
        {
            _mapper = mapper;
            _userProfileSettingRepository = userProfileSettingRepository;
        }
        public async Task<List<UserProfileSettingListViewModel>> Handle(GetUserProfileSettingQuery request, CancellationToken cancellationToken)
        {
            var all = await _userProfileSettingRepository.GetAllAsync();

            return _mapper.Map<List<UserProfileSettingListViewModel>>(all);

        }
    }
}
