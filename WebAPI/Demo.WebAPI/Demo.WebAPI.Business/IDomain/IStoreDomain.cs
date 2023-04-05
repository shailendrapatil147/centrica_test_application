using Demo.WebAPI.Contracts.Entites;

namespace Demo.WebAPI.Domain.IDomain
{
    public interface IStoreDomain
    {
        Task<int> AddStoreAsync(Store Store);
        Task<IEnumerable<StoreByCityId>> GetAllStoresByCityIdAsync(int CityId);
    }
}
