using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Common;
using Moq;
using System.Linq;
using PersonRepository.Service.MyService;

namespace PersonRepository.Service.Tests
{
    [TestClass]
    public class ServiceRepositoryTests
    {
        public IPersonService GetTestService()
        {
            var people = new List<Person>()
            {
                new Person() {FirstName = "John", LastName = "Smith",
                    Rating = 7, StartDate = new DateTime(2000, 10, 1)},
                new Person() {FirstName = "Mary", LastName = "Thomas",
                    Rating = 9, StartDate = new DateTime(1971, 7, 23)},
            };

            var svcMock = new Mock<IPersonService>();
            svcMock.Setup(s => s.GetPeople()).Returns(people.ToArray());
            svcMock.Setup(s => s.GetPerson(It.IsAny<string>())).Returns((string n) => people.FirstOrDefault(p => p.LastName == n));
            return svcMock.Object;
        }

        [TestMethod]
        public void GetPeople_OnExecute_ReturnsPeople()
        {
            // Arrange
            var repo = new ServiceRepository();
            repo.ServiceProxy = GetTestService();

            // Act
            var output = repo.GetPeople();

            // Assert
            Assert.IsNotNull(output);
            Assert.AreEqual(2, output.Count());
        }

        [TestMethod]
        public void GetPerson_OnExecuteWithValidValue_ReturnsPerson()
        {
            // Arrange
            var repo = new ServiceRepository();
            repo.ServiceProxy = GetTestService();

            // Act
            var output = repo.GetPerson("Smith");

            // Assert
            Assert.IsNotNull(output);
            Assert.AreEqual("Smith", output.LastName);
        }

        [TestMethod]
        public void GetPerson_OnExecuteWithInvalidValue_ReturnsNull()
        {
            // Arrange
            var repo = new ServiceRepository();
            repo.ServiceProxy = GetTestService();

            // Act
            var output = repo.GetPerson("NOTAREALPERSON");

            // Assert
            Assert.IsNull(output);
        }
    }
}
