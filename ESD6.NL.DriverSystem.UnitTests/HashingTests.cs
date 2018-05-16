using ESD6NL.DriverSystem.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESD6.NL.DriverSystem.UnitTests
{
    [TestClass]
    public class HashingTests
    {
        [TestMethod]
        public void TestGetSalt_ReturnsSalt()
        {
            string salt = HashingHelper.getSalt();

            Assert.AreEqual(24,salt.Length);
        }
        
        [TestMethod]
        public void TestHashingHelper_UsernameAndPassword_ReturnsHash()
        {
            string hash = HashingHelper.generatePasswordHash("test", HashingHelper.getSalt());
            Assert.IsNotNull(hash);
        }

        [TestMethod]
        public void ValidatePassword_ValidInput_ReturnsTrue()
        {
            string salt = HashingHelper.getSalt();
            string hash = HashingHelper.generatePasswordHash("test", salt);

            Assert.IsTrue(HashingHelper.Validate("test", salt, hash));
        }

        [TestMethod]
        public void ValidateHelper_WrongPassword_ReturnsFalse()
        {
            string salt = HashingHelper.getSalt();
            string hash = HashingHelper.generatePasswordHash("test", salt);

            Assert.IsFalse(HashingHelper.Validate("test1", salt, hash));
        }
        [TestMethod]
        public void ValidateHelper_InvalidHash_ReturnsFalse()
        {
            string salt = HashingHelper.getSalt();

            Assert.IsFalse(HashingHelper.Validate("test1", salt, "lolhash:lol"));
        }

        [TestMethod]
        public void ValidateHelper_InvalidSalt_ReturnsFalse()
        {
            string salt = HashingHelper.getSalt();
            string hash = HashingHelper.generatePasswordHash("test", salt);

            Assert.IsFalse(HashingHelper.Validate("test1", "Lolsalt", hash));
        }
    }
}
