using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Responses;

namespace Users.Application.Functions.Users.Commands.CreateUser
{
    public class CreateUserCommandResponse : BaseResponse
    {
        public int? UserId { get; set; }

        public CreateUserCommandResponse() : base()
        { }
        
        public CreateUserCommandResponse(ValidationResult validationResult) : base(validationResult)
        { }
        
        public CreateUserCommandResponse(string message) : base(message)
        { }
        public CreateUserCommandResponse(string message, bool success) : base(message, success)
        { }
        
        public CreateUserCommandResponse(int userId)
        { 
            UserId = userId;
        }




        
    }
}
