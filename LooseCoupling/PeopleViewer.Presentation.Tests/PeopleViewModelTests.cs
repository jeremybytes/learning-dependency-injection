using Common;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleViewer.Presentation.Tests
{
    public class PeopleViewModelTests
    {
        private IPersonRepository GetTestRepository()
        {
            return new FakeRepository();
        }

        [Test]
        public void RefreshPeople_OnExecute_PeopleIsPopulated()
        {
            // Arrange
            var repository = GetTestRepository();
            var vm = new PeopleViewModel(repository);

            // Act
            vm.RefreshPeople();

            // Assert
            Assert.IsNotNull(vm.People);
            Assert.AreEqual(2, vm.People.Count());
        }

        [Test]
        public void ClearPeople_OnExecute_PeopleIsEmpty()
        {
            // Arrange
            var repository = GetTestRepository();
            var vm = new PeopleViewModel(repository);
            vm.RefreshPeople();
            Assert.AreEqual(2, vm.People.Count(), "Invalid Arrangement");

            // Act
            vm.ClearPeople();

            // Assert
            Assert.AreEqual(0, vm.People.Count());
        }
    }
}
