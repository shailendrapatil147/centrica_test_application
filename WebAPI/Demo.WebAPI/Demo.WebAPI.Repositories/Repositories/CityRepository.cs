using Dapper;
using Demo.WebAPI.Common.Extensions;
using Demo.WebAPI.Contracts.Entites;
using Demo.WebAPI.Repositories.IRepositories;
using System.Data.SqlClient;
using System.Data;

namespace Demo.WebAPI.Repositories.Repositories
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(string ConnectionString) : base(ConnectionString)
        {
        }

        public async Task<IEnumerable<City>> GetAllCityAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var multi = await connection.QueryMultipleAsync("spCity_GetAll", commandType: CommandType.StoredProcedure))
                {
                    IEnumerable<City> result = await multi.ReadAsync<City>();
                    return result;
                }
            }
        }
    }
}
