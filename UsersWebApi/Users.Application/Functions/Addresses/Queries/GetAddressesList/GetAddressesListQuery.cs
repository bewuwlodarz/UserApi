using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Functions.Addresses.Queries.GetAddressesList
{
    public class GetAddressesListQuery : IRequest<List<AddressInListViewModel>>
    {
    }
}
