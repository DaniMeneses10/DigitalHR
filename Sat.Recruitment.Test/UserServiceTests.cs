using Sat.Recruitment.Api.DataAccess;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserServiceTests
    {
        [Fact]
        public void CalculateMoney_Normal_Success()
        {
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);
            var user = new User() { UserType = "Normal", Money = 50 };

            userService.CalculateMoney(user);

            Assert.Equal(90, user.Money);
        }

        [Fact]
        public void CalculateMoney_Normal_Fail()
        {
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);
            var user = new User() { UserType = "Normal", Money = 70 };

            userService.CalculateMoney(user);

            Assert.NotEqual(100, user.Money);
        }

        [Fact]
        public void CalculateMoney_SuperUser_Success()
        {
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);
            var user = new User() { UserType = "SuperUser", Money = 200 };

            userService.CalculateMoney(user);

            Assert.Equal(240, user.Money);
        }

        [Fact]
        public void CalculateMoney_SuperUser_Fail()
        {
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);
            var user = new User() { UserType = "SuperUser", Money = 70 };

            userService.CalculateMoney(user);

            Assert.NotEqual(100, user.Money);
        }
    }
}
