using Xunit;

namespace DemoLibrary.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(3, 2, 5)]
        [InlineData(5, 3, 8)]
        [InlineData(21, 5.25, 26.25)]
        [InlineData(0, 0, 0)]
        [InlineData(-2, -3, -5)]
        [InlineData(double.MaxValue, 5, double.MaxValue)]
        [InlineData(double.MinValue, -5, double.MinValue)]
        public void Add_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            // Arrange

            // Act
            double actual = CalculatorService.Add(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8, 4, 2)]
        public void Divide_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            // Arrange

            // Act
            var actual = CalculatorService.Divide(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Divide_DivideByZero()
        {
            // Arrange
            var expected = 0;

            // Act
            var actual = CalculatorService.Divide(15, 0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 2, 6)]
        [InlineData(5, 3, 15)]
        [InlineData(21, 5.25, 110.25)]
        [InlineData(0, 0, 0)]
        [InlineData(-2, -3, 6)]
        public void Multiply_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            // Arrange
            // Act
            double actual = CalculatorService.Multiply(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(5, 3, 2)]
        [InlineData(21, 5.25, 15.75)]
        [InlineData(0, 0, 0)]
        [InlineData(-2, -3, 1)]
        [InlineData(double.MaxValue, 5, double.MaxValue)]
        [InlineData(double.MinValue, -5, double.MinValue)]
        public void Subtract_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            // Arrange
            // Act
            double actual = CalculatorService.Subtract(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
