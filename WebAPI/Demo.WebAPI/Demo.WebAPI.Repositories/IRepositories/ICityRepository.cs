using Demo.WebAPI.Contracts.Entites;

namespace Demo.WebAPI.Repositories.IRepositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCityAsync();
    }
}
