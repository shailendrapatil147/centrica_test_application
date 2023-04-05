using Demo.WebAPI.Domain.IDomain;

namespace Demo.WebAPI.Repositories
{
    public interface IDomainFactory
    {
        public IUserDomain UserDomain { get; set; }
        public ICityDomain CityDomain { get; set; }
        public IStoreDomain StoreDomain { get; set; }
    }
}
