namespace Core.Models
{
    public class UserModel
    {
        public string Id { get; set; }   
        public string Login { get; set; }   
        public string Password { get; set; }   
        public string[] Permissions { get; set; }   
    }
}