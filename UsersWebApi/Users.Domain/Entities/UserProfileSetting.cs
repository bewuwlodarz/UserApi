using System;

namespace Users.Domain.Entities
{
    public class UserProfileSetting
    {
        public int UserProfileSettingId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsExtraUser { get; set; }
        public string FavouriteFrontendFramework { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}