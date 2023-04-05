namespace Demo.WebAPI.Contracts.Entites
{
    public class UserByCityId
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int UserRoleId { get; set; }
    }
}
