using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Responses;

namespace Users.Application.Functions.UserProfileSettings.Commands.CreateUserProfileSetting
{
    public class CreateUserProfileSettingCommandResponse : BaseResponse
    {
        public int? UserProfileSettingId { get; set; }

        public CreateUserProfileSettingCommandResponse() : base()
        { }
        
        public CreateUserProfileSettingCommandResponse(ValidationResult validationResult) : base(validationResult)
        { }
        
        public CreateUserProfileSettingCommandResponse(string message) : base(message)
        { }
        public CreateUserProfileSettingCommandResponse(string message, bool success) : base(message, success)
        { }
        
        public CreateUserProfileSettingCommandResponse(int userProfileSettingId)
        {
            UserProfileSettingId = userProfileSettingId;
        }



}
}
