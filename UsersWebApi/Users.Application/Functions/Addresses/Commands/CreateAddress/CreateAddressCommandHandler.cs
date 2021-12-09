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

namespace Users.Application.Functions.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreateAddressCommandResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAddressCommandValidator(_addressRepository);
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                return new CreateAddressCommandResponse(validatorResult);

            var address = _mapper.Map<Address>(request);
            address = await _addressRepository.AddAsync(address);
            return new CreateAddressCommandResponse(address.AddressId);
        }

    }
}  
