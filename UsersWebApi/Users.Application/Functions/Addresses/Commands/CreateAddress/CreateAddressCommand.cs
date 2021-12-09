using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Functions.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<CreateAddressCommandResponse>
        {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
