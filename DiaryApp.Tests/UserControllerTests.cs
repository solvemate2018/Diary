using System.Collections.Generic;
using System.Linq;
using DiaryApp.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Moq;
using DiaryApp.Data;
using DiaryApp.Controllers;
using System;

namespace DiaryApp.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Login_Tests()
        {
            var data = new List<User>
            {
                new User("FirstUser", "FirstPass"),
                new User("SecondUser", "SecondPass"),
                new User("ThirdUser", "ThirdPass"),
                new User("FourthUser", "FourthPass")
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DiaryContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            var service = new UserController(mockContext.Object);
            bool canLoginOne = service.Login("FirstUser", "FirstPass");
            bool canLoginTwo = service.Login("SecondUser", "SecondPass");
            bool canLoginTree = service.Login("ThirdUser", "ThirdPass");
            bool canLoginFour = service.Login("FourthUser", "FourthPass");

            Assert.AreEqual(canLoginOne, true);
            Assert.AreEqual(canLoginTwo, true);
            Assert.AreEqual(canLoginTree, true);
            Assert.AreEqual(canLoginFour, true);
            Assert.ThrowsException<ArgumentException>(() =>service.Login("FakeUser", "FakePass"));
            Assert.ThrowsException<ArgumentException>(() => service.Login("FirstUser", "FakePass"));
        }

        [TestMethod]
        public void Register_Tests()
        {
            var data = new List<User>
            {
                new User("FirstUser", "FirstPass"),
                new User("SecondUser", "SecondPass"),
                new User("ThirdUser", "ThirdPass"),
                new User("FourthUser", "FourthPass")
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DiaryContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            var service = new UserController(mockContext.Object);

            bool canRegistrate = service.Registrate("FifthUser", "FifthPass", "FifthPass");

            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.ThrowsException<ArgumentException>(() => service.Registrate("LastUser", "LastPass", "FirstPass"));
            Assert.ThrowsException<ArgumentException>(() => service.Registrate("FirstUser", "FakePass", "FakePass"));
            Assert.ThrowsException<ArgumentException>(() => service.Registrate("No", "FakePass", "FakePass"));
            Assert.ThrowsException<ArgumentException>(() => service.Registrate("FirstUser", "No", "No"));
        }
    }
}
