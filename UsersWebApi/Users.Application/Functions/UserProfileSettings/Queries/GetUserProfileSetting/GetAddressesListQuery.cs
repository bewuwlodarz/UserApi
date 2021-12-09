using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Functions.UserProfileSettings.Queries.GetUserProfileSetting
{
    public class GetUserProfileSettingQuery : IRequest<List<UserProfileSettingListViewModel>>
    {
    }
}
