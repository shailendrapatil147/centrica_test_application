namespace Demo.WebAPI.Contracts.Entites
{
    public class UserRole
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int UserId { get; set; }
        public int RoleId{ get; set; }
        public DateTime CreateDateUTC { get; set; }
        public DateTime UpdateDateUTC { get; set; }
    }
}
