using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApplication.Controllers;

namespace SampleApplications.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewData["Message"]);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ItTakesOptionalName()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About("") as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewData["Message"]);
        }

        [TestMethod]
        public void ItReturnsNameInMessage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About("Fred") as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.Fred", result.ViewData["Message"]);
        }
    }
}
