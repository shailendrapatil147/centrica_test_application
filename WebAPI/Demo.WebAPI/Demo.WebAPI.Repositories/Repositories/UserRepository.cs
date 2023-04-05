using Dapper;
using Demo.WebAPI.Common.Extensions;
using Demo.WebAPI.Contracts.Entites;
using Demo.WebAPI.Repositories.IRepositories;
using System.Data.SqlClient;
using System.Data;

namespace Demo.WebAPI.Repositories.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string ConnectionString) : base(ConnectionString)
        {
        }

        public async Task<int> AddUserAsync(User User)
        {
            User.ThrowIfArgumentNull(nameof(User));
            using (var connection = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@Name", User.Name);
                var result = await connection.QuerySingleOrDefaultAsync<int>("[dbo].[spUser_Upsert]", param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var multi = await connection.QueryMultipleAsync("spUser_GetAll", commandType: CommandType.StoredProcedure))
                {
                    IEnumerable<User> result = await multi.ReadAsync<User>();
                    return result;
                }
            }
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var multi = await connection.QueryMultipleAsync("spUserRoles_GetAll", commandType: CommandType.StoredProcedure))
                {
                    IEnumerable<Role> result = await multi.ReadAsync<Role>();
                    return result;
                }
            }
        }

        public async Task<IEnumerable<UserByCityId>> GetAllUsersByCityIdAsync(int CityId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@CityId", CityId);
                using (var multi = await connection.QueryMultipleAsync("spUser_GetAllByCityId", param, commandType: CommandType.StoredProcedure))
                {
                    IEnumerable<UserByCityId> result = await multi.ReadAsync<UserByCityId>();
                    return result;
                }
            }
        }

        public async Task<string> AddUserRoleAsync(UserRole UserRole)
        {
            UserRole.ThrowIfArgumentNull(nameof(UserRole));
            using (var connection = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@UserId", UserRole.UserId);
                param.Add("@RoleId", UserRole.RoleId);
                param.Add("@CityId", UserRole.CityId);
                try
                {
                    var result = await connection.QuerySingleOrDefaultAsync<int>("[dbo].[spUserRole_Upsert]", param, commandType: CommandType.StoredProcedure);
                    return result.ToString();
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
