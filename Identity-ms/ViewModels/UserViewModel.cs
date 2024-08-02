namespace Identity_ms.ViewModels
{
    public class UserViewModel
    {
        public string user_name { get; set; }
        public string password { get; set; }
        public RoleEnum role { get; set; }
    }

    public enum RoleEnum
    {
        Admin = 1,
        User = 2,
    }
}
