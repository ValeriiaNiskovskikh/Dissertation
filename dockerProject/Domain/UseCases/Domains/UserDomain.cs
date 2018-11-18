using Core.Models;
using UseCases.Models;

namespace UseCases.Domains
{
    public class UserDomain : IUserDomain
    {
        public UseCaseAnswer<UserModel> Login(string login, string encryptPassword)
        {
            throw new System.NotImplementedException();
        }

        public UseCaseAnswer<UserModel> GetPermissions(string login)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IUserDomain
    {
        UseCaseAnswer<UserModel> Login(string login, string encryptPassword);
        UseCaseAnswer<UserModel> GetPermissions(string login);
    }
}