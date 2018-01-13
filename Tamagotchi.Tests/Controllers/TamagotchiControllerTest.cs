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
    public class TamagotchiControllerTest
    {

        [TestMethod]
        public void GetTamagotchiIndex()
        {
            // Arrange
            TamagotchiController controller = new TamagotchiController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTamagotchiCreate()
        {
            // Arrange
            TamagotchiController controller = new TamagotchiController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTamagotchiEdit()
        {
            // Arrange
            TamagotchiController controller = new TamagotchiController();

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTamagotchiDelete()
        {
            // Arrange
            TamagotchiController controller = new TamagotchiController();

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTamagotchiDetails()
        {
            // Arrange
            TamagotchiController controller = new TamagotchiController();

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostTamagotchiEdit()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void PostTamagotchiDelete()
        {
            throw new NotImplementedException();
        }

        private void GetContext(out ITamagotchiRepository repository, out Mock<DbSet<Tamagochi>> set, out Mock<TamagotchiEntities> context)
        {
            List<Tamagochi> data = new List<Tamagochi>
            {
                new Tamagochi()
                {
                    Id = 1,
                    Name = "Daano v Ethopie",
                    Level = 0,
                    Age = 0,
                    Alive = 1,
                    Currency = 100,
                    Hapinness = 0,
                    Health = 100
                },

                new Tamagochi()
                {
                    Id = 2,
                    Name = "Daan v Ethopie",
                    Level = 0,
                    Age = 0,
                    Alive = 1,
                    Currency = 100,
                    Hapinness = 0,
                    Health = 100
                },

                new Tamagochi()
                {
                    Id = 3,
                    Name = "Piet v Piet",
                    Level = 0,
                    Age = 0,
                    Alive = 1,
                    Currency = 100,
                    Hapinness = 0,
                    Health = 100
                },

                new Tamagochi()
                {
                    Id = 4,
                    Name = "Piethenjk v Ethopie",
                    Level = 0,
                    Age = 0,
                    Alive = 1,
                    Currency = 100,
                    Hapinness = 0,
                    Health = 100
                },

                new Tamagochi()
                {
                    Id = 5,
                    Name = "Henk v Ethopie",
                    Level = 0,
                    Age = 0,
                    Alive = 1,
                    Currency = 100,
                    Hapinness = 0,
                    Health = 100
                },

                new Tamagochi()
                {
                    Id = 6,
                    Name = "Piet v Ethopie",
                    Level = 0,
                    Age = 0,
                    Alive = 1,
                    Currency = 100,
                    Hapinness = 0,
                    Health = 100
                }
            };

            Mock<DbSet<Tamagochi>> mockSet = new Mock<DbSet<Tamagochi>>();
            mockSet.As<IQueryable<Tamagochi>>().Setup(x => x.Provider).Returns(data.AsQueryable().Provider);
            mockSet.As<IQueryable<Tamagochi>>().Setup(x => x.Expression).Returns(data.AsQueryable().Expression);
            mockSet.As<IQueryable<Tamagochi>>().Setup(x => x.ElementType).Returns(data.AsQueryable().ElementType);
            mockSet.As<IQueryable<Tamagochi>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(x => x.Add(It.IsAny<Tamagochi>())).Callback<Tamagochi>(x => data.Add(x));
            mockSet.Setup(x => x.Remove(It.IsAny<Tamagochi>())).Callback<Tamagochi>(x => data.Remove(x));

            Mock<TamagotchiEntities> contextMock = new Mock<TamagotchiEntities>();
            contextMock.Setup(x => x.Tamagochis).Returns(mockSet.Object);

            repository = new TamagotchiDatabaseRepository(contextMock.Object);
            set = mockSet;
            context = contextMock;
        }
    }
}
