using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Contracts.Persistance;
using Users.Persistence.EF.Repositories;

namespace Users.Persistence.EF
{
    public static class PersistenceWithEFRegistration
    {
        public static IServiceCollection AddUsersPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UsersContext>(options => options.UseSqlServer(configuration.GetConnectionString("UsersConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileSettingRepository, UserProfileSettingRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            return services;
        }
    }
}
