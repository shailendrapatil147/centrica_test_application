namespace Demo.WebAPI.Contracts.Entites
{
    public class StoreByCityId
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
