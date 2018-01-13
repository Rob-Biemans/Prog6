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
    public class BookingControllerTest
    {
        [TestMethod]
        public void GetBookingIndex()
        {
            // Arrange
            BookingController controller = new BookingController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBookingCreate()
        {
            // Arrange
            BookingController controller = new BookingController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBookingEdit()
        {
            // Arrange
            BookingController controller = new BookingController();

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBookingDelete()
        {
            // Arrange
            BookingController controller = new BookingController();

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBookingDetails()
        {
            // Arrange
            BookingController controller = new BookingController();

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostBookingEdit()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void PostBookingDelete()
        {
            throw new NotImplementedException();
        }

        private void GetContext(out IBookingRepository repository, out Mock<DbSet<Booking>> set, out Mock<TamagotchiEntities> context)
        {
            List<Booking> data = new List<Booking>
            {
                new Booking()
                {
                    Id = 1,
                    Nights = 2,
                    HotelroomId = 2,
                    TamagotchiId = 1
                },

                new Booking()
                {
                    Id = 2,
                    Nights = 2,
                    HotelroomId = 3,
                    TamagotchiId = 1
                },

                new Booking()
                {
                    Id = 3,
                    Nights = 2,
                    HotelroomId = 1,
                    TamagotchiId = 1
                },

                new Booking()
                {
                    Id = 4,
                    Nights = 2,
                    HotelroomId = 4,
                    TamagotchiId = 2
                },

                new Booking()
                {
                    Id = 5,
                    Nights = 2,
                    HotelroomId = 5,
                    TamagotchiId = 4
                },

                new Booking()
                {
                    Id = 6,
                    Nights = 2,
                    HotelroomId = 6,
                    TamagotchiId = 2
                }
            };

            Mock<DbSet<Booking>> mockSet = new Mock<DbSet<Booking>>();
            mockSet.As<IQueryable<Booking>>().Setup(x => x.Provider).Returns(data.AsQueryable().Provider);
            mockSet.As<IQueryable<Booking>>().Setup(x => x.Expression).Returns(data.AsQueryable().Expression);
            mockSet.As<IQueryable<Booking>>().Setup(x => x.ElementType).Returns(data.AsQueryable().ElementType);
            mockSet.As<IQueryable<Booking>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(x => x.Add(It.IsAny<Booking>())).Callback<Booking>(x => data.Add(x));
            mockSet.Setup(x => x.Remove(It.IsAny<Booking>())).Callback<Booking>(x => data.Remove(x));

            Mock<TamagotchiEntities> contextMock = new Mock<TamagotchiEntities>();
            contextMock.Setup(x => x.Bookings).Returns(mockSet.Object);

            repository = new BookingDatabaseRepository(contextMock.Object);
            set = mockSet;
            context = contextMock;
        }
    }
}
