using ASPNETCore_React.Web.Controllers.API.Example;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ASPNETCore_React.Test.Web.API
{
    public class ExampleControllerTests
    {
        [Fact]
        public void Get_ReturnStringArray_NotEmpty()
        {
            // Arrange
            var controller = new ExampleController();

            // Act
            var result = controller.Get();

            // Assert
            var list = Assert.IsType<string[]>(result);
            Assert.NotEmpty(list);
        }

        [Fact]
        public void Get_ReturnStringItem_Value1()
        {
            // Arrange
            var controller = new ExampleController();

            // Act
            var result = controller.Get(1);

            // Assert
            var value = Assert.IsType<string>(result);
            Assert.Equal(value, "value1");
        }

        [Fact]
        public void Post_NoReturn_NoExeption()
        {
            // Arrange
            var controller = new ExampleController();

            // Act
            controller.Post("");

            // Assert
            // As This example dont have a repository, 
            // we are not able to verify if the object was fully updated
        }

        [Fact]
        public void Put_NoReturn_NoExeption()
        {
            // Arrange
            var controller = new ExampleController();

            // Act
            controller.Put(1, "");

            // Assert
            // As This example dont have a repository, 
            // we are not able to verify if the object was partially updated
        }

        [Fact]
        public void Delete_NoReturn_NoExeption()
        {
            // Arrange
            var controller = new ExampleController();

            // Act
            controller.Delete(1);

            // Assert
            // As This example dont have a repository, 
            // we are not able to verify if the object was deleted
        }
    }
}
