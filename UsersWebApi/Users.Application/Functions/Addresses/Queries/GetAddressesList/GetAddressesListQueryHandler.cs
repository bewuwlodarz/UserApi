using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Users.Application.Contracts.Persistance;
using Users.Domain.Entities;

namespace Users.Application.Functions.Addresses.Queries.GetAddressesList
{
    public class GetAddressesListQueryHandler : IRequestHandler<GetAddressesListQuery, List<AddressInListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Address> _addressRepository;
        public GetAddressesListQueryHandler(IMapper mapper, IAsyncRepository<Address> addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }
        public async Task<List<AddressInListViewModel>> Handle(GetAddressesListQuery request, CancellationToken cancellationToken)
        {
            var all = await _addressRepository.GetAllAsync();

            return _mapper.Map<List<AddressInListViewModel>>(all);

        }
    }
}
