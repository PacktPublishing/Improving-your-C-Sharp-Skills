using System;
using Xunit;

namespace CodeKata
{
    public class Test1
    {
        [Fact]
        public void Given3ThenFizz()
        {
            // Arrange
            // Act
            var result = FizzBuzz(3);

            // Assert 
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void Given5ThenBuzz()
        {
            // Arrange
            // Act
            var result = FizzBuzz(5);

            // Assert
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void Given15ThenFizzBuzz()
        {
            // Arrange  
            // Act
            var result = FizzBuzz(15);

            // Assert
            Assert.Equal("FizzBuzz", result);
        }

        [Fact]
        public void Given1Then1()
        {
            // Arrange
            // Act 
            var result = FizzBuzz(1);

            // Assert 
            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        public void GivenDivisibleBy3And5ThenFizzBuzz(int number)
        {
            // Arrange
            // Act
            var result = FizzBuzz(number);

            // Assert
            Assert.Equal("FizzBuzz", result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        [InlineData(8)]
        public void GivenNonDivisibleGreaterThan1ThenNumberNotFound(int number)
        {
            // Arrange
            // Act
            var result = FizzBuzz(number);

            // Assert
            Assert.Equal("Number not found", result);
        }

        private object FizzBuzz(int value)
        {
            if (value % 15 == 0)
                return "FizzBuzz";
            if (value % 5 == 0)
                return "Buzz";
            if (value % 3 == 0)
                return "Fizz";
            return value == 1 ? (object)value : "Number not found";
        }
    }
}
