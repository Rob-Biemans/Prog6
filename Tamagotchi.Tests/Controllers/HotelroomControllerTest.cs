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
    public class HotelroomControllerTest
    {
        [TestMethod]
        public void GetHotelroomIndex()
        {
            // Arrange
            HotelroomController controller = new HotelroomController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetHotelroomCreate()
        {
            // Arrange
            HotelroomController controller = new HotelroomController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetHotelroomEdit()
        {
            // Arrange
            HotelroomController controller = new HotelroomController();

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetHotelroomDelete()
        {
            // Arrange
            HotelroomController controller = new HotelroomController();

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetHotelroomDetails()
        {
            // Arrange
            HotelroomController controller = new HotelroomController();

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostHotelroomEdit()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void PostHotelroomDelete()
        {
            throw new NotImplementedException();
        }

        private void GetContext(out IHotelroomRepository repository, out Mock<DbSet<Hotelroom>> set, out Mock<TamagotchiEntities> context)
        {
            List<Hotelroom> data = new List<Hotelroom>
            {
                new Hotelroom()
                {
                    Id = 1,
                    Beds = 3,
                    Price = 10,
                    Type = "REST"
                },

                new Hotelroom()
                {
                    Id = 2,
                    Beds = 2,
                    Price = 25,
                    Type = "WORK"
                },

                new Hotelroom()
                {
                    Id = 3,
                    Beds = 5,
                    Price = 100,
                    Type = "FIGHT"
                },

                new Hotelroom()
                {
                    Id = 4,
                    Beds = 5,
                    Price = 20,
                    Type = "GAME"
                },

                new Hotelroom()
                {
                    Id = 5,
                    Beds = 3,
                    Price = 10,
                    Type = "REST"
                },

                new Hotelroom()
                {
                    Id = 6,
                    Beds = 2,
                    Price = 20,
                    Type = "GAME"
                }
            };

            Mock<DbSet<Hotelroom>> mockSet = new Mock<DbSet<Hotelroom>>();
            mockSet.As<IQueryable<Hotelroom>>().Setup(x => x.Provider).Returns(data.AsQueryable().Provider);
            mockSet.As<IQueryable<Hotelroom>>().Setup(x => x.Expression).Returns(data.AsQueryable().Expression);
            mockSet.As<IQueryable<Hotelroom>>().Setup(x => x.ElementType).Returns(data.AsQueryable().ElementType);
            mockSet.As<IQueryable<Hotelroom>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(x => x.Add(It.IsAny<Hotelroom>())).Callback<Hotelroom>(x => data.Add(x));
            mockSet.Setup(x => x.Remove(It.IsAny<Hotelroom>())).Callback<Hotelroom>(x => data.Remove(x));

            Mock<TamagotchiEntities> contextMock = new Mock<TamagotchiEntities>();
            contextMock.Setup(x => x.Hotelrooms).Returns(mockSet.Object);

            repository = new HotelroomDatabaseRepository(contextMock.Object);
            set = mockSet;
            context = contextMock;
        }
    }
}
