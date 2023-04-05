using Demo.WebAPI.Contracts.Entites;
using Demo.WebAPI.Domain.IDomain;
using Demo.WebAPI.Repositories;

namespace Demo.WebAPI.Domain.Domain
{
    public class UserDomain : BaseDomain, IUserDomain
    {
        public UserDomain(IRepositoryFactory RepositoryFactory) : base(RepositoryFactory)
        {
        }

        public async Task<int> AddUserAsync(User User)
        {
            return await RepositoryFactory.UserRepository.AddUserAsync(User);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await RepositoryFactory.UserRepository.GetAllUsersAsync();
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await RepositoryFactory.UserRepository.GetAllRolesAsync();
        }

        public async Task<IEnumerable<UserByCityId>> GetAllUsersByCityIdAsync(int CityId)
        {
            return await RepositoryFactory.UserRepository.GetAllUsersByCityIdAsync(CityId);
        }

        public async Task<string> AddUserRoleAsync(UserRole UserRole)
        {
            return await RepositoryFactory.UserRepository.AddUserRoleAsync(UserRole);
        }
    }
}
