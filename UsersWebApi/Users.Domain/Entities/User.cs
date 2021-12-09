using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Common;

namespace Users.Domain.Entities
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public int UserAddressId { get; set; }
        public Address UserAddress { get; set; }
        public int UserProfileSettingId { get; set; }
        public UserProfileSetting UserProfileSetting {get; set;}

    }
}
