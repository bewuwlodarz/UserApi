using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Entities;
using Users.Application.Contracts.Persistance;


namespace Users.Persistence.EF.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(UsersContext dbContext) : base(dbContext)
        {
        }

    }
}
