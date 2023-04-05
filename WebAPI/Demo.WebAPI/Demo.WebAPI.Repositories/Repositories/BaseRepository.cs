using Demo.WebAPI.Common.Extensions;

namespace Demo.WebAPI.Repositories.Repositories
{
    public class BaseRepository
    {
        #region " Protected properties "
        protected readonly string _connectionString;
        #endregion

        public BaseRepository(string ConnectionString)
        {
            _connectionString = ConnectionString.ThrowIfArgumentNullOrEmpty(nameof(ConnectionString));
        }
    }
}
