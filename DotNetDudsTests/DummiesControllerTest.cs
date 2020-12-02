using DotNetDuds.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetDudsTests
{
    [TestClass]
    public class DummiesControllerTest
    {
        [TestMethod]
        public void IndexReturnsSomething()
        {
            // arrange - set up any variables / objects needed for the method & scenario we want to test
            var controller = new DummiesController();

            // act - execute the method and store the result returned (if any)
            var result = controller.Index();

            // assert - evaluate if the result is as expected
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexLoadsIndexView()
        {
            // arrange - set up any variables / objects needed for the method & scenario we want to test
            var controller = new DummiesController();

            // act - execute the method and store the result returned (if any). Must cast IActionResult return type to a ViewResult
            var result = (ViewResult)controller.Index();

            // assert - does the Index view get returned?
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexViewDataHasMessage()
        {
            // arrange
            var controller = new DummiesController();

            // act
            var result = (ViewResult)controller.Index();

            // assert - did we get the right message in the ViewData["Message"] property?
            Assert.AreEqual("This is a message from the controller", result.ViewData["Message"]);
        }
    }
}
