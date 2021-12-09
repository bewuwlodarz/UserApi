using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Users.Application.Contracts.Persistance;
using Users.Domain.Entities;

namespace Users.Application.Functions.Users
{
    public class GetuserDetailQueryHandler : IRequestHandler<GetUserDetailListQuery, UserDetailViewModel>
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IAsyncRepository<Address> _addressRepository;
        private readonly IAsyncRepository<UserProfileSetting> _userProfileSettingRepository;
        private readonly IMapper _mapper;


        public GetuserDetailQueryHandler(IAsyncRepository<User> userRepository, IAsyncRepository<Address> addressRepository, IAsyncRepository<UserProfileSetting> userProfileSettingRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _userProfileSettingRepository = userProfileSettingRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailViewModel> Handle(GetUserDetailListQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user != null)
            {
                var userDetail = _mapper.Map<UserDetailViewModel>(user);
                var address = await _addressRepository.GetByIdAsync(user.UserAddressId);
                userDetail.UserAddress = _mapper.Map<AddressDto>(address);
                var userProfileSetting = await _userProfileSettingRepository.GetByIdAsync(user.UserProfileSettingId);
                userDetail.UserProfileSetting = _mapper.Map<UserProfileSettingDto>(userProfileSetting);
                return userDetail;
            }
            return null;

        }

    }
}
