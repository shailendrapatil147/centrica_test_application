using Demo.WebAPI.Contracts.Entites;

namespace Demo.WebAPI.Domain.IDomain
{
    public interface ICityDomain
    {
        Task<IEnumerable<City>> GetAllCityAsync();
    }
}
