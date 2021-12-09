using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Users.Application.Contracts.Persistance;

namespace Users.Application.Functions.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        private readonly IAddressRepository _addressRepository;
        public CreateAddressCommandValidator(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            RuleFor(u => u.City)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull();
            
              
        }

    }
}
