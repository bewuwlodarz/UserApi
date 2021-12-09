using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Users.Application.Contracts.Persistance;

namespace Users.Application.Functions.UserProfileSettings.Commands.CreateUserProfileSetting
{
    public class CreateUserProfileSettingCommandValidator : AbstractValidator<CreateUserSettingProfileCommand>
    {
        private readonly IUserProfileSettingRepository _userProfileSettingRepository;
        public CreateUserProfileSettingCommandValidator(IUserProfileSettingRepository userProfileSettingRepository)
        {
            _userProfileSettingRepository = userProfileSettingRepository;
            RuleFor(u => u)
                .Must(IsDateOfBirthNotToday)
                .WithMessage("Cannot get future users yet");
            
              
        }

        private bool IsDateOfBirthNotToday(CreateUserSettingProfileCommand createUserSettingProfileCommand)
        {
            return (createUserSettingProfileCommand.DateOfBirth < DateTime.Today);
        }

    }
}
