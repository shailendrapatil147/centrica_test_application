using Demo.WebAPI.Contracts.Entites;

namespace Demo.WebAPI.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<int> AddUserAsync(User User);
        Task<IEnumerable<UserByCityId>> GetAllUsersByCityIdAsync(int CityId);
        Task<string> AddUserRoleAsync(UserRole UserRole);
        Task<IEnumerable<Role>> GetAllRolesAsync();
    }
}
