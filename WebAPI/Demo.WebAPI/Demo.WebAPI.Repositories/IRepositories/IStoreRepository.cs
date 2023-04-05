using Demo.WebAPI.Contracts.Entites;

namespace Demo.WebAPI.Repositories.IRepositories
{
    public interface IStoreRepository
    {
        Task<int> AddStoreAsync(Store Store);
        Task<IEnumerable<StoreByCityId>> GetAllStoresByCityIdAsync(int CityId);
    }
}
