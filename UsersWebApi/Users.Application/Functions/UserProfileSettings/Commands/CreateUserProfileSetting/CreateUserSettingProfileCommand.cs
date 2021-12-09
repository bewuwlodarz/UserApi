using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Functions.UserProfileSettings.Commands.CreateUserProfileSetting
{
    public class CreateUserSettingProfileCommand : IRequest<CreateUserProfileSettingCommandResponse>
    {
        public int UserProfileSettingId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsExtraUser { get; set; }
        public string FavouriteFrontendFramework { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
