using System.Text;
using Core.Services;
using NUnit.Framework;

namespace CoreTests
{
    public class PasswordServiceTests
    {
        private IPasswordService _passwordService;

        [SetUp]
        public void Setup()
        {
            _passwordService = new PasswordService();
        }

        [TestCase("sh", "sl")]
        [TestCase("sh", "slt")]
        [TestCase("short", "salt")]
        [TestCase("veryveryverylongveryveryverylong", "slt")]
        [TestCase("veryveryverylongveryveryverylong", "saltsaltsaltsaltsaltsaltsaltsaltsalt")]
        public void ValidLength(string password, string salt)
        {
            var encrypt = _passwordService.Encrypt(password, salt);
            Assert.AreEqual(32, encrypt.Length);
        }
    }
}