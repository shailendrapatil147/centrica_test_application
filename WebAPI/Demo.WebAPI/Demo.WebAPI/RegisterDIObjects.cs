using Demo.WebAPI.Common.Constants;
using Demo.WebAPI.Domain.Domain;
using Demo.WebAPI.Domain.IDomain;
using Demo.WebAPI.Repositories;
using Demo.WebAPI.Repositories.IRepositories;
using Demo.WebAPI.Repositories.Repositories;

namespace Demo.WebAPI
{
    public static class RegisterDIObjects
    {

        public static void RegisterDomains(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDomainFactory, DomainFactory>();
            builder.Services.AddScoped<IUserDomain, UserDomain>();
            builder.Services.AddScoped<ICityDomain, CityDomain>();
            builder.Services.AddScoped<IStoreDomain, StoreDomain>();
        }

        public static void RegisterRepositories(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString(StringConstants.CONNECTIONSTRINGNAME);

            builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            builder.Services.AddScoped<IUserRepository, UserRepository>(_ => new UserRepository(connectionString));
            builder.Services.AddScoped<ICityRepository, CityRepository>(_ => new CityRepository(connectionString));
            builder.Services.AddScoped<IStoreRepository, StoreRepository>(_ => new StoreRepository(connectionString));
        }
    }
}
