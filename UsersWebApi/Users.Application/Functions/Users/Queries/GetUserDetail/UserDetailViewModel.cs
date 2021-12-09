using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Functions.Users
{
    public class UserDetailViewModel
    {

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public AddressDto UserAddress { get; set; }
        public UserProfileSettingDto UserProfileSetting { get; set; }
    }
}
