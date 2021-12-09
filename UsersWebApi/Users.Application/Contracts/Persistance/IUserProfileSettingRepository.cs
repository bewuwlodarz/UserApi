using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Entities;

namespace Users.Application.Contracts.Persistance
{
    public interface IUserProfileSettingRepository : IAsyncRepository<UserProfileSetting>
    {
    }
}
