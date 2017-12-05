using ASPNETCore_React.Domain.Models;
using ASPNETCore_React.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ASPNETCore_React.Test.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public void Add_ReturnUser_AddedAndFilled()
        {
            // Arrange
            var repository = new UserRepository();

            // Act
            var result = repository.Add(new User() { Name = "Teste1" });
            
            // Assert
            Assert.NotNull(result);
            var user = Assert.IsType<User>(result);
            Assert.True(user.Id > 0);
        }

        [Fact]
        public void List_ReturnAllUsersList_All()
        {
            // Arrange 
            var repository = new UserRepository();

            // Act
            repository.Add(new User() { Name = "List" });
            var allUsers = repository.List();

            // Assert
            ICollection<User> result = Assert.IsAssignableFrom<ICollection<User>>(allUsers);
            Assert.NotEmpty(result);
            Assert.True(result.Count == 1);
        }

        [Fact]
        public void Update_ReturnUser_UpdatedAndFilled()
        {
            // Arrange 
            var repository = new UserRepository();

            // Act
            var user = repository.Add(new User() { Name = "Update1" });
            user.Name = "Update2";
            var updated = repository.Modify(user);

            // Assert
            var result = Assert.IsType<User>(updated);
            Assert.True(result.Name == "Update2");
        }

        [Fact]
        public void Delete_ReturnBollean_True()
        {
            // Arrange 
            var repository = new UserRepository();

            // Act
            var user = repository.Add(new User() { Name = "Delete" });
            bool deleted = repository.Delete(user.Id);

            // Assert
            Assert.True(deleted);
            Assert.Empty(repository.List(name: "Delete"));
        }
    }
}
