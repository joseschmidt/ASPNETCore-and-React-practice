using ASPNETCore_React.Domain.Database;
using ASPNETCore_React.Domain.Models;
using ASPNETCore_React.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ASPNETCore_React.Test.Repositories
{
    public class UserRepositoryTests: IDisposable
    {
        UserRepository repository;
        DomainContext context;

        public UserRepositoryTests()
        {
            context = new DomainContext(new Microsoft.EntityFrameworkCore.DbContextOptions<DomainContext>());
            repository = new UserRepository(context);
        }

        public void Dispose() { }

        [Fact]
        public void Add_ReturnUser_AddedAndFilled()
        {
            // Arrange & Act
            var result = repository.Add(new User() { Name = "Teste1" });
            repository.SaveChanges();

            // Assert
            Assert.NotNull(result);
            var user = Assert.IsType<User>(result);
            Assert.True(user.Id > 0);
        }

        [Fact]
        public void List_ReturnAllUsersList_All()
        {
            // Arrange & Act
            repository.Add(new User() { Name = "List" });
            repository.SaveChanges();

            var allUsers = repository.List();

            // Assert
            ICollection<User> result = Assert.IsAssignableFrom<ICollection<User>>(allUsers);
            Assert.NotEmpty(result);
            Assert.True(result.Count == 1);
        }

        [Fact]
        public void Update_ReturnUser_UpdatedAndFilled()
        {
            // Arrange & Act
            var user = repository.Add(new User() { Name = "Update1" });
            repository.SaveChanges();

            user.Name = "Update2";
            var updated = repository.Modify(user);
            repository.SaveChanges();

            // Assert
            var result = Assert.IsType<User>(updated);
            Assert.True(result.Name == "Update2");
        }

        [Fact]
        public void Delete_ReturnBollean_True()
        {
            // Arrange & Act
            var user = repository.Add(new User() { Name = "Delete" });
            repository.SaveChanges();

            bool deleted = repository.Delete(user);
            repository.SaveChanges();

            // Assert
            Assert.True(deleted);
            Assert.Empty(repository.List(name: "Delete"));
        }
    }
}
