using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using Tamagotchi.Domein.Models;
using Tamagotchi.Domein.Repository;
using System;
using System.Linq;

namespace Tamagotchi.Tests
{
    [TestClass]
    public class HotelroomDatabaseRepositoryTest
    {
        [TestMethod]
        public void HotelroomDatabaseGetAll()
        {
            // Arrange
            IHotelroomRepository repository;
            Mock<DbSet<Hotelroom>> set;
            Mock<TamagotchiEntities> context;
            GetContext(out repository, out set, out context);

            // Act
            List<Hotelroom> a = repository.GetAll();

            // Assert
            Assert.AreEqual(6, a.Count);
        }

        [TestMethod]
        public void HotelroomDatabaseAdd()
        {
            // Arrange
            IHotelroomRepository repository;
            Mock<DbSet<Hotelroom>> set;
            Mock<TamagotchiEntities> context;
            GetContext(out repository, out set, out context);

            Hotelroom h = new Hotelroom()
            {
                Id = 7,
                Beds = 3,
                Price = 10,
                Type = "REST"
            };

            // Act
            repository.Add(h);

            // Assert
            set.Verify(x => x.Add(It.IsAny<Hotelroom>()), Times.Once());
            List<Hotelroom> added = set.Object.Where(x => x.Id == 7).ToList();
            Assert.AreEqual(1, added.Count);
            Assert.AreEqual(7, added[0].Id);
            Assert.AreEqual(3, added[0].Beds);
            Assert.AreEqual(10, added[0].Price);
            Assert.AreEqual("REST", added[0].Type);
        }

        [TestMethod]
        public void HotelroomDatabaseRemove()
        {
            // Arrange
            IHotelroomRepository repository;
            Mock<DbSet<Hotelroom>> set;
            Mock<TamagotchiEntities> context;
            GetContext(out repository, out set, out context);

            Hotelroom h = set.Object.Where(x => x.Id == 1).ToList()[0];

            // Act
            repository.Remove(h);

            // Assert
            set.Verify(x => x.Remove(It.IsAny<Hotelroom>()), Times.Once());
            Assert.AreEqual(0, set.Object.Where(x => x.Id == 1).ToList().Count);
        }

        [TestMethod]
        public void HotelroomDatabaseUpdate()
        {
            // Arrange
            IHotelroomRepository repository;
            Mock<DbSet<Hotelroom>> set;
            Mock<TamagotchiEntities> context;
            GetContext(out repository, out set, out context);

            Hotelroom h = new Hotelroom()
            {
                Id = 1,
                Beds = 3,
                Price = 10,
                Type = "REST"
            };

            // Act
            repository.Add(h);

            // Assert
            set.Verify(x => x.Add(It.IsAny<Hotelroom>()), Times.Once());
            List<Hotelroom> updated = set.Object.Where(x => x.Id == 1).ToList();
            Assert.AreEqual(2, updated.Count);
            Assert.AreEqual(1, updated[0].Id);
            Assert.AreEqual(3, updated[0].Beds);
            Assert.AreEqual(10, updated[0].Price);
            Assert.AreEqual("REST", updated[0].Type);
        }

        [TestMethod]
        public void HotelroomDatabaseForceRefresh()
        {
            // Arrange
            IHotelroomRepository repository;
            Mock<DbSet<Hotelroom>> set;
            Mock<TamagotchiEntities> context;
            GetContext(out repository, out set, out context);

            // Act
            bool refreshed = repository.ForceRefresh();

            // Assert
            Assert.IsTrue(refreshed);
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
