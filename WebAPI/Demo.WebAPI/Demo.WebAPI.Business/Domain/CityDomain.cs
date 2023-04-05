using Demo.WebAPI.Contracts.Entites;
using Demo.WebAPI.Domain.IDomain;
using Demo.WebAPI.Repositories;

namespace Demo.WebAPI.Domain.Domain
{
    public class CityDomain : BaseDomain, ICityDomain
    {
        public CityDomain(IRepositoryFactory RepositoryFactory) : base(RepositoryFactory)
        {
        }

        public async Task<IEnumerable<City>> GetAllCityAsync()
        {
            return await RepositoryFactory.CityRepository.GetAllCityAsync();
        }
    }
}
