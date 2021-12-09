using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Users.Domain.Common;
using Users.Domain.Entities;
using Users.Persistence.EF.DummyData;

namespace Users.Persistence.EF
{
    public class UsersContext : DbContext
    {

        public UsersContext(DbContextOptions<UsersContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserProfileSetting> UserProfileSettings { get; set;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersContext).Assembly);

            foreach (var item in DummyUsers.GetDummyUsers())
            {
                modelBuilder.Entity<User>().HasData(item);
            }
            
            foreach (var item in DummyAddresses.GetDummyAddress())
            {
                modelBuilder.Entity<Address>().HasData(item);
            }
            
            
            foreach (var item in DummyUserProfileSettings.GetDummyUserProfileSettings())
            {
                modelBuilder.Entity<UserProfileSetting>().HasData(item);
            }

        }
    }
}
