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
    public class TamagotchiDatabaseRepositoryTest
    {
        [TestMethod]
        public void TamagotchiDatabaseGetAll()
        {
            // Arrange
            ITamagotchiRepository repository;
            Mock<DbSet<Tamagochi>> set;
            Mock<TamagotchiEntities> context;
            GetContext(out repository, out set, out context);

            // Act
            List<Tamagochi> a = repository.GetAll();

            // Assert
            Assert.AreEqual(6, a.Count);
        }

        [TestMethod]
        public void TamagotchiDatabaseAdd()
        {
            // Arrange
            ITamagotchiRepository repository;
            Mock<DbSet<Tamagochi>> set;
            Mock<TamagotchiEntities> context;
            GetContext(out repository, out set, out context);

            Tamagochi t = new Tamagochi()
            {
                Id = 7,
                Name = "Roberto v Ethopie",
                Level = 0,
                Age = 0,
                Alive = 1,
                Currency = 100,
                Hapinness = 0,
                Health = 100
            };

            // Act
            repository.Add(t);

            // Assert
            set.Verify(x => x.Add(It.IsAny<Tamagochi>()), Times.Once());
            List<Tamagochi> added = set.Object.Where(x => x.Id == 7).ToList();
            Assert.AreEqual(1, added.Count);
            Assert.AreEqual(7, added[0].Id);
            Assert.AreEqual("Roberto v Ethopie", added[0].Name);
            Assert.AreEqual(0, added[0].Level);
            Assert.AreEqual(0, added[0].Age);
            Assert.AreEqual(1, added[0].Alive);
            Assert.AreEqual(100, added[0].Currency);
            Assert.AreEqual(0, added[0].Hapinness);
            Assert.AreEqual(100, added[0].Health);
        }

        [TestMethod]
        public void TamagotchiDatabaseRemove()
        {
            // Arrange
            ITamagotchiRepository repository;
            Mock<DbSet<Tamagochi>> set;
            Mock<TamagotchiEntities> context;
            GetContext(out repository, out set, out context);

            Tamagochi t = set.Object.Where(x => x.Id == 1).ToList()[0];

            // Act
            repository.Remove(t);

            // Assert
            set.Verify(x => x.Remove(It.IsAny<Tamagochi>()), Times.Once());
            Assert.AreEqual(0, set.Object.Where(x => x.Id == 1).ToList().Count);
        }

        [TestMethod]
        public void TamagotchiDatabaseUpdate()
        {
            // Arrange
            ITamagotchiRepository repository;
            Mock<DbSet<Tamagochi>> set;
            Mock<TamagotchiEntities> context;
            GetContext(out repository, out set, out context);

            Tamagochi t = new Tamagochi()
            {
                Id = 1,
                Name = "Daano v Ethopie",
                Level = 0,
                Age = 0,
                Alive = 1,
                Currency = 100,
                Hapinness = 0,
                Health = 100
            };

            // Act
            repository.Add(t);

            // Assert
            set.Verify(x => x.Add(It.IsAny<Tamagochi>()), Times.Once());
            List<Tamagochi> updated = set.Object.Where(x => x.Id == 1).ToList();
            Assert.AreEqual(2, updated.Count);
            Assert.AreEqual(1, updated[0].Id);
            Assert.AreEqual("Daano v Ethopie", updated[0].Name);
            Assert.AreEqual(0, updated[0].Level);
            Assert.AreEqual(0, updated[0].Age);
            Assert.AreEqual(1, updated[0].Alive);
            Assert.AreEqual(100, updated[0].Currency);
            Assert.AreEqual(0, updated[0].Hapinness);
            Assert.AreEqual(100, updated[0].Health);
        }

        [TestMethod]
        public void TamagotchiDatabaseForceRefresh()
        {
            // Arrange
            ITamagotchiRepository repository;
            Mock<DbSet<Tamagochi>> set;
            Mock<TamagotchiEntities> context;
            GetContext(out repository, out set, out context);

            // Act
            bool refreshed = repository.ForceRefresh();

            // Assert
            Assert.IsTrue(refreshed);
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
