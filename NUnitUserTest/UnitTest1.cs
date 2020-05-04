using NUnit.Framework;
using ProductManagementDBEntity.Models;
using SHR_Model;
using System;
using System.Threading.Tasks;
using UserManagement.Repositories;

namespace NUnitUserTest
{
    [TestFixture]
    public class Tests
    {
        UserRepository _userRepository;
        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository(new ProductDBContext());
        }

        [Test]
        [Description("TestUserLogin")]
        public async Task TestUserLogin()
        {
            var result = await _userRepository.UserLogin(new UserLogin()
            {
                UserName = "Devika",
                UserPassword = "devika"
            });
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("TestUserRegister")]
        public async Task TestUserRegister()
        {
            await _userRepository.UserRegister(new UserDetails()
            {
                FirstName = "Devika",
                LastName = "G",
                UserName = "Devika",
                UserPassword = "devika",
                EmailAddr = "devika@gmail.com",
                PhoneNumber = "9987566767",
                CreateDate = DateTime.Now,
                UserAddress = "Ponnur"

            });
        }
        [Test]
        [Description("View Profile")]
        public async Task TestViewProfile()
        {
            var result = await _userRepository.ViewProfile(1);
            Assert.NotNull(result);
        }
        [Test]
        [Description("Update User")]
        public async Task UpdateUser()
        {
            UserDetails user = await _userRepository.ViewProfile(1);
            user.LastName="V";
            await _userRepository.UpdateProfile(user);
            UserDetails user1 = await _userRepository.ViewProfile(1);
            Assert.AreSame(user, user1);

        }
    }
}