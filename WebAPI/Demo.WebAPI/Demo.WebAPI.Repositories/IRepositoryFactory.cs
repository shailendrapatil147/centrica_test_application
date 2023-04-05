using Demo.WebAPI.Repositories.IRepositories;

namespace Demo.WebAPI.Repositories
{
    public interface IRepositoryFactory
    {
        public IUserRepository UserRepository { get; set; }
        public ICityRepository CityRepository { get; set; }
        public IStoreRepository StoreRepository { get; set; }
    }
}
