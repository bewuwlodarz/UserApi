using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Entities;
using Users.Application.Contracts.Persistance;


namespace Users.Persistence.EF.Repositories
{
    public class UserProfileSettingRepository : BaseRepository<UserProfileSetting>, IUserProfileSettingRepository
    {
        public UserProfileSettingRepository(UsersContext dbContext) : base(dbContext)
        {
        }

    }
}
