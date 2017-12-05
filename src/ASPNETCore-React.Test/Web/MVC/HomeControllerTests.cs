using ASPNETCore_React.Web.Controllers.MVC;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ASPNETCore_React.Test.Web.MVC
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsAViewResult_Empty()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.Model);
        }
    }
}
