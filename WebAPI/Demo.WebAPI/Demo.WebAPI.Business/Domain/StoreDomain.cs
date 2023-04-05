using Demo.WebAPI.Contracts.Entites;
using Demo.WebAPI.Domain.IDomain;
using Demo.WebAPI.Repositories;

namespace Demo.WebAPI.Domain.Domain
{
    public class StoreDomain : BaseDomain, IStoreDomain
    {
        public StoreDomain(IRepositoryFactory RepositoryFactory) : base(RepositoryFactory)
        {
        }

        public async Task<int> AddStoreAsync(Store Store)
        {
            return await RepositoryFactory.StoreRepository.AddStoreAsync(Store);
        }

        public async Task<IEnumerable<StoreByCityId>> GetAllStoresByCityIdAsync(int CityId)
        {
            return await RepositoryFactory.StoreRepository.GetAllStoresByCityIdAsync(CityId);
        }
    }
}
