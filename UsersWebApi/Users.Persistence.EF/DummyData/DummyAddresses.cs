using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Entities;

namespace Users.Persistence.EF.DummyData
{
    public static class DummyAddresses
    {
        public static List<Address> GetDummyAddress()
        {
            List<Address> users = new List<Address>()
            {
                new Address()
                {
                    AddressId = 1,
                    City = "Wroclaw",
                    Street = "Kosciuszki",
                    PostCode = "50-008",
                    Country = "Poland"
                },

                new Address()
                {
                    AddressId = 2,
                    City = "Kielce",
                    Street = "Kosciuszki",
                    PostCode = "25-351",
                    Country = "Poland"
                },

            };
            return users;
        }
    }
}
