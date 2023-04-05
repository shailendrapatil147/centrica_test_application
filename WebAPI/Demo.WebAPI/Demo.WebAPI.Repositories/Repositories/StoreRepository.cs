using Dapper;
using Demo.WebAPI.Common.Extensions;
using Demo.WebAPI.Contracts.Entites;
using Demo.WebAPI.Repositories.IRepositories;
using System.Data.SqlClient;
using System.Data;

namespace Demo.WebAPI.Repositories.Repositories
{
    public class StoreRepository : BaseRepository, IStoreRepository
    {
        public StoreRepository(string ConnectionString) : base(ConnectionString)
        {
        }

        public async Task<int> AddStoreAsync(Store Store)
        {
            Store.ThrowIfArgumentNull(nameof(Store));
            using (var connection = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@StoreName", Store.Name);
                param.Add("@CityId", Store.CityId);
                param.Add("@Description", Store.Description);
                var result = await connection.QuerySingleOrDefaultAsync<int>("[dbo].[spStore_Upsert]", param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<StoreByCityId>> GetAllStoresByCityIdAsync(int CityId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@CityId", CityId);
                using (var multi = await connection.QueryMultipleAsync("spStore_GetAllByCityId", param, commandType: CommandType.StoredProcedure))
                {
                    IEnumerable<StoreByCityId> result = await multi.ReadAsync<StoreByCityId>();
                    return result;
                }
            }
        }
    }
}
