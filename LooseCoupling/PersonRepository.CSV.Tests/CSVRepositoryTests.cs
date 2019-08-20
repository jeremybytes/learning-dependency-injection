using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace PersonRepository.CSV.Tests
{
    public class CSVRepositoryTests
    {
        [Test]
        public void GetPeople_WithEmptyFile_ReturnsEmptyList()
        {
            var repository = new CSVRepository();
            repository.FileLoader = new FakeFileLoader("Empty");

            var result = repository.GetPeople();

            Assert.IsEmpty(result);
        }

        [Test]
        public void GetTask_WithNoFile_ThrowsFileNotFoundException()
        {
            var repository = new CSVRepository();

            try
            {
                var result = repository.GetPeople();
                Assert.Fail();
            }
            catch (FileNotFoundException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void GetPeople_WithGoodRecords_ReturnsGoodRecords()
        {
            var repository = new CSVRepository();
            repository.FileLoader = new FakeFileLoader("Good");

            var result = repository.GetPeople();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetPeople_WithBadRecords_ReturnsGoodRecords()
        {
            var repository = new CSVRepository();
            repository.FileLoader = new FakeFileLoader("Mixed");

            var result = repository.GetPeople();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetPeople_WithOnlyBadRecord_ReturnsEmptyList()
        {
            var repository = new CSVRepository();
            repository.FileLoader = new FakeFileLoader("Bad");

            var result = repository.GetPeople();

            Assert.IsEmpty(result);
        }

    }
}
