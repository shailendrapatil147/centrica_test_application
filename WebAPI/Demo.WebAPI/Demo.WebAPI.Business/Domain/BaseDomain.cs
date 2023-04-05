using Demo.WebAPI.Repositories;

namespace Demo.WebAPI.Domain.Domain
{
    public class BaseDomain
    {
        protected IRepositoryFactory RepositoryFactory { get; set; }
        public BaseDomain(IRepositoryFactory RepositoryFactory)
        {
            this.RepositoryFactory = RepositoryFactory;
        }
    }
}
