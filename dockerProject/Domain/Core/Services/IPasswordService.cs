namespace Core.Services
{
    public interface IPasswordService
    {
        string Encrypt(string password, string salt);
    }
}