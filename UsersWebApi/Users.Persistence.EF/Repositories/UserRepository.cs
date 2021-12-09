using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Contracts.Persistance;
using Users.Domain.Entities;

namespace Users.Persistence.EF.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UsersContext dbContext): base(dbContext)
        { 
        }

        public Task<bool> IsNameAndSurnameAlreadyExist(string name, string surname)
        {
            var matches = _dbContext.Users.Any(x => x.Name.Equals(name) && x.Surname.Equals(surname));
            return Task.FromResult(matches);
        }
    }
}
