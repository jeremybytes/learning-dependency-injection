using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace PeopleViewer.Presentation.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        public IPersonRepository GetTestRepository()
        {
            var people = new List<Person>()
            {
                new Person() {FirstName = "John", LastName = "Smith",
                    Rating = 7, StartDate = new DateTime(2000, 10, 1)},
                new Person() {FirstName = "Mary", LastName = "Thomas",
                    Rating = 9, StartDate = new DateTime(1971, 7, 23)},
            };

            var repoMock = new Mock<IPersonRepository>();
            repoMock.Setup(r => r.GetPeople()).Returns(people);
            return repoMock.Object;
        }

        [TestMethod]
        public void People_OnRefreshCommand_IsPopulated()
        {
            // Arrange
            var repository = GetTestRepository();
            var vm = new MainWindowViewModel(repository);

            // Act
            vm.RefreshPeopleCommand.Execute(null);

            // Assert
            Assert.IsNotNull(vm.People);
            Assert.AreEqual(2, vm.People.Count());
        }

        [TestMethod]
        public void People_OnClearCommand_IsEmpty()
        {
            // Arrange
            var repository = GetTestRepository();
            var vm = new MainWindowViewModel(repository);
            vm.RefreshPeopleCommand.Execute(null);
            Assert.AreEqual(2, vm.People.Count(), "Invalid Arrangement");

            // Act
            vm.ClearPeopleCommand.Execute(null);

            // Assert
            Assert.AreEqual(0, vm.People.Count());
        }
    }
}
