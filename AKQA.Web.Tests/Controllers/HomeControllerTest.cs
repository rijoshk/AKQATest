using AKQA.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AKQA.Web.Tests.Controllers
{
    [TestClass]
    class HomeControllerTest
    {
        [TestMethod]
        public void Index_Get_HomeControllerIndexView()
        {
            // Arrange
            var controller = new HomeController();
            // Act
            ActionResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", result.ToString());
        } 
    }
}
