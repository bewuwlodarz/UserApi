using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Responses;

namespace Users.Application.Functions.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandResponse : BaseResponse
    {
        public int? AddressId { get; set; }

        public CreateAddressCommandResponse() : base()
        { }
        
        public CreateAddressCommandResponse(ValidationResult validationResult) : base(validationResult)
        { }
        
        public CreateAddressCommandResponse(string message) : base(message)
        { }
        public CreateAddressCommandResponse(string message, bool success) : base(message, success)
        { }
        
        public CreateAddressCommandResponse(int addressId)
        {
            AddressId = addressId;
        }




        
    }
}
