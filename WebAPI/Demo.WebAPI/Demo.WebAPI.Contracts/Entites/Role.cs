namespace Demo.WebAPI.Contracts.Entites
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDateUTC { get; set; }
        public DateTime UpdateDateUTC { get; set; }
    }
}
