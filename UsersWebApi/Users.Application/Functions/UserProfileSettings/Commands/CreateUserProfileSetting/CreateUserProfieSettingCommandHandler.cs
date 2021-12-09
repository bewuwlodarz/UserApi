using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Users.Application.Contracts.Persistance;
using Users.Application.Functions.Users.Commands.CreateUser;
using Users.Domain.Entities;

namespace Users.Application.Functions.UserProfileSettings.Commands.CreateUserProfileSetting
{
    public class CreateUserProfieSettingCommandHandler : IRequestHandler<CreateUserSettingProfileCommand, CreateUserProfileSettingCommandResponse>
    {
        private readonly IUserProfileSettingRepository _userProfileSettingRepository;
        private readonly IMapper _mapper;

        public CreateUserProfieSettingCommandHandler(IUserProfileSettingRepository userProfileSettingRepository, IMapper mapper)
        {
            _userProfileSettingRepository = userProfileSettingRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserProfileSettingCommandResponse> Handle(CreateUserSettingProfileCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserProfileSettingCommandValidator(_userProfileSettingRepository);
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                return new CreateUserProfileSettingCommandResponse(validatorResult);

            var userProfileSetting = _mapper.Map<UserProfileSetting>(request);
            userProfileSetting = await _userProfileSettingRepository.AddAsync(userProfileSetting);
            return new CreateUserProfileSettingCommandResponse(userProfileSetting.UserProfileSettingId);
        }

    }
}
