namespace Dog_Barber_Shop_API.Models
{
    public class UserRoles
    {
        public const string Client = "Client";
        public const string Admin = "Admin";
        public const string ClientOrAdmin = Client + "," + Admin;
    }
}
