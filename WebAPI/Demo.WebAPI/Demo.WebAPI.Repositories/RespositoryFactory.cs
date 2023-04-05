using Demo.WebAPI.Repositories.IRepositories;

namespace Demo.WebAPI.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public ICityRepository CityRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IStoreRepository StoreRepository { get; set; }

        public RepositoryFactory(IUserRepository userRepository, ICityRepository cityRepository, IStoreRepository storeRepository)
        {
            UserRepository = userRepository;
            CityRepository = cityRepository;
            StoreRepository = storeRepository;
        }
    }
}
