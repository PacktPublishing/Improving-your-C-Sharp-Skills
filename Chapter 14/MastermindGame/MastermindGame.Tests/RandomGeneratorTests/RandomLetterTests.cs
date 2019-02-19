using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MastermindGame.Tests.RandomGeneratorTests
{
    public class RandomLetterTests
    {
        private readonly MockRandomGenerator _rand;

        public RandomLetterTests()
        {
            _rand = new MockRandomGenerator();
        }

        [Fact]
        public void ItExists()
        {
            _rand.Letter();
        }

        [Fact]
        public void ItReturnsDefaultValue()
        {
            // Act
            var result = _rand.Letter();

            // Assert
            Assert.Equal('A', result);
        }

        [Fact]
        public void ItCanReturnPredeterminedLetters()
        {
            // Arrange
            _rand.SetLetters('A', 'B', 'C', 'D', 'E');

            // Act
            var a = _rand.Letter();
            var b = _rand.Letter();
            var c = _rand.Letter();
            var d = _rand.Letter();
            var e = _rand.Letter();

            // Assert
            Assert.Equal('A', a);
            Assert.Equal('B', b);
            Assert.Equal('C', c);
            Assert.Equal('D', d);
            Assert.Equal('E', e);
        }

        [Fact]
        public void ItCanHaveAMaxRange()
        {
            // Arrange
            const char maxRange = 'C';
            _rand.SetLetters('A', 'B', 'C', 'D', 'E');

            // Act
            var a = _rand.Letter(maxRange);
            var b = _rand.Letter(maxRange);
            var c = _rand.Letter(maxRange);
            var d = _rand.Letter(maxRange);
            var e = _rand.Letter(maxRange);

            // Arrange
            Assert.Equal('A', a);
            Assert.Equal('B', b);
            Assert.Equal('C', c);
            Assert.Equal('C', d);
            Assert.Equal('C', e);
        }

        [Fact]
        public void ItCanHaveAMinMaxRange()
        {
            // Arrange
            const char minRange = 'B';
            const char maxRange = 'C';
            _rand.SetLetters('A', 'B', 'C', 'D', 'E');

            // Act
            var a = _rand.Letter(minRange, maxRange);
            var b = _rand.Letter(minRange, maxRange);
            var c = _rand.Letter(minRange, maxRange);
            var d = _rand.Letter(minRange, maxRange);
            var e = _rand.Letter(minRange, maxRange);

            // Arrange
            Assert.Equal('B', a);
            Assert.Equal('B', b);
            Assert.Equal('C', c);
            Assert.Equal('C', d);
            Assert.Equal('C', e);
        }
    }
}
