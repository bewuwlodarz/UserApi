using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Contracts.Persistance;
using Users.Domain.Entities;

namespace Users.Application.UnitTest.Mocks
{
    public class RepositoryMocks
    {

        public static Mock<IUserRepository> GetUserRepository()
        {
            var users = GetUsers();
            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);
            mockUserRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    return users.FirstOrDefault(x => x.UserId == id);
                });

            mockUserRepository.Setup(repo => repo.AddAsync(It.IsAny<User>())).ReturnsAsync(
                (User user) =>
                {
                    users.Add(user);
                    return user;
                });

            mockUserRepository.Setup(repo => repo.DeleteAsync(It.IsAny<User>())).Callback<User>(
                (user) =>
                {
                    users.Remove(user);
                });

            mockUserRepository.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).Callback<User>(
                (user) =>
                {
                    users.Remove(user);
                    users.Add(user);
                });

            mockUserRepository.Setup(repo => repo.IsNameAndSurnameAlreadyExist(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(
                (string name, string surname) =>
                {
                    return users.Any(x => x.Name == name && x.Surname == surname);
                });

            return mockUserRepository;

        }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    UserId = 1,
                    Name = "Bartek",
                    Surname = "Wlodarz",
                    EmailAddress = "bartek.wlodarz@gmail.com",

                },

                new User()
                {
                    UserId = 2,
                    Name = "Dawid",
                    Surname = "Wlodarz",
                    EmailAddress = "dawid.wlodarz@gmail.com",

                },

            };
            return users;
        }
    }
}