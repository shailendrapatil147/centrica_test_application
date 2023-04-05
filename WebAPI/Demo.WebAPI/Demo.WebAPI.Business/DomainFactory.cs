using Demo.WebAPI.Domain.IDomain;

namespace Demo.WebAPI.Repositories
{
    public class DomainFactory : IDomainFactory
    {
        public IUserDomain UserDomain { get; set; }
        public ICityDomain CityDomain { get; set; }
        public IStoreDomain StoreDomain { get; set; }

        public DomainFactory(IUserDomain userDomain, ICityDomain cityDomain, IStoreDomain storeDomain)
        {
            UserDomain = userDomain;
            CityDomain = cityDomain;
            StoreDomain = storeDomain;
        }
    }
}
