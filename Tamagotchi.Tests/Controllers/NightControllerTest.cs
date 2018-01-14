using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Tamagotchi.Controllers;
using Tamagotchi.Domein;
using Tamagotchi.Domein.Repository;
using Tamagotchi.Models;

namespace Tamagotchi.Tests.Controllers
{
    [TestClass]
    public class NightControllerTest
    {
        [TestMethod]
        public void GetBookingIndex()
        {
            // Arrange
            NightController controller = new NightController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
