using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Entities;

namespace Users.Persistence.EF.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> userBuilder)
        {
            userBuilder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(20);

            userBuilder.Property(u => u.Surname)
                .IsRequired()
                .HasMaxLength(30);
        }
      
    }
}
