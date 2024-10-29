using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Xunit;

namespace DemoLibrary.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            // Arrange
            var newPerson =
                new PersonModel
                {
                    FirstName = "Fernando",
                    LastName = "JS"
                };

            var people = new List<PersonModel>();

            // Act
            DataAccessService.AddPersonToPeopleList(people, newPerson);

            // Assert
            Assert.True(people.Count == 1);
            Assert.Contains<PersonModel>(newPerson, people);
        }

        [Theory]
        [InlineData("Fernando", "", "LastName")]
        [InlineData("", "JS", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
        {
            // Arrange
            var newPerson =
                new PersonModel
                {
                    FirstName = firstName,
                    LastName = lastName
                };

            var people = new List<PersonModel>();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(param, () => DataAccessService.AddPersonToPeopleList(people, newPerson));
        }

        [Fact]
        public void ConvertModelsToCSV_ShouldWork()
        {
            // Assert
            var expectPerson = new PersonModel()
            {
                FirstName = "Fernando",
                LastName = "JS",
            };

            var expected = new List<PersonModel>()
            {
                expectPerson,
                new PersonModel()
                {
                    FirstName = "Tim",
                    LastName = "Corey",
                },
            };

            // Act
            var result = DataAccessService.ConvertModelsToCSV(expected);

            // Arrange
            Assert.True(result.Count == 2);
            Assert.Contains<string>("Fernando,JS", result);
        }

        [Fact]
        public void ConvertModelsToCSV_ShouldThrowExceptionWhenNull()
        {
            // Assert
            // Act
            // Arrange
            Assert.Throws<ArgumentException>("people", () => DataAccessService.ConvertModelsToCSV(null));
        }

        [Fact]
        public void WriteTextFileContent_ShouldWork()
        {
            // Arrange
            var stream = new[] { "Fernando,JS", "Tim,Corey", "John,Doe" };
            var expected = new List<PersonModel>()
            {
                new PersonModel()
                {
                    FirstName = "Fernando",
                    LastName = "JS",
                },
                new PersonModel()
                {
                    FirstName = "Tim",
                    LastName = "Corey",
                },
                new PersonModel()
                {
                    FirstName = "John",
                    LastName = "Doe",
                },
            };

            // Act
            var result = DataAccessService.WriteTextFileContent(stream);

            // Assert
            Assert.True(result.Count == 3);
            Assert.True(expected.Count == result.Count);
            Assert.Contains(result, x => x.FirstName.Equals(expected.FirstOrDefault().FirstName));
        }

        [Fact]
        public void WriteTextFileContent_ShouldFailWhenNull()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<NullReferenceException>(() => DataAccessService.WriteTextFileContent(null));
        }
    }
}
