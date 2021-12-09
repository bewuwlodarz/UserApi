using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Entities;

namespace Users.Persistence.EF.DummyData
{
    public class DummyUsers
    {
        public static List<User> GetDummyUsers()
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    UserId = 1,
                    Name = "Bartek",
                    Surname = "Wlodarz",
                    EmailAddress = "bartek.wlodarz@gmail.com",
                    UserAddressId = 1,
                    UserProfileSettingId = 1
                },

                new User()
                {
                    UserId = 2,
                    Name = "Dawid",
                    Surname = "Wlodarz",
                    EmailAddress = "dawid.wlodarz@gmail.com",
                    UserAddressId = 2,
                    UserProfileSettingId = 2
                },

            };
            return users;
        }
    }
}
