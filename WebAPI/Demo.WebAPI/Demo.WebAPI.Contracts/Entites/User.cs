namespace Demo.WebAPI.Contracts.Entites
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDateUTC { get; set; }
        public DateTime UpdateDateUTC { get; set; }
    }
}
