using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Entities;

namespace Users.Persistence.EF.DummyData
{
    public static class DummyUserProfileSettings
    {
        public static List<UserProfileSetting> GetDummyUserProfileSettings()
        {
            List<UserProfileSetting> users = new List<UserProfileSetting>()
            {
                new UserProfileSetting()
                {
                    UserProfileSettingId = 1,
                    IsAdmin = true,
                    IsExtraUser = false,
                    DateOfBirth = DateTime.Today.AddYears(-25),
                    FavouriteFrontendFramework = "React"
                },

                new UserProfileSetting()
                {
                    UserProfileSettingId = 2,
                    IsAdmin = false,
                    IsExtraUser = true,
                    DateOfBirth = DateTime.Today.AddYears(-20),
                    FavouriteFrontendFramework = "Vue.JS"
                },

            };
            return users;
        }
    }
}
