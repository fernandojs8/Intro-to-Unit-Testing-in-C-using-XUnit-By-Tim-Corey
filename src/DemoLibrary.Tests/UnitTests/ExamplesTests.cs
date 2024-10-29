using System;
using Xunit;

namespace DemoLibrary.Tests
{
    public class ExamplesTests
    {
        [Fact]
        public void ExampleLoadTextFile_ValidNameShouldWork()
        {
            // Arrange
            string actual = ExamplesService.ExampleLoadTextFile("This is a valid file name.");

            // Act

            // Assert
            Assert.True(actual.Length > 0);
        }

        [Fact]
        public void ExampleLoadTextFile_InvalidNameShouldFail()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentException>("file", () => ExamplesService.ExampleLoadTextFile(String.Empty));
        }
    }
}
