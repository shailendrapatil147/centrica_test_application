using Demo.WebAPI.Contracts.Entites;

namespace Demo.WebAPI.Domain.IDomain
{
    public interface IUserDomain
    {
        Task<int> AddUserAsync(User User);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<IEnumerable<UserByCityId>> GetAllUsersByCityIdAsync(int CityId);
        Task<string> AddUserRoleAsync(UserRole UserRole);
    }
}
