using Xunit;

namespace MastermindGame.Tests
{
    public class RandomNumberTests
    {
        private readonly MockRandomGenerator _rand;

        public RandomNumberTests()
        {
            _rand = new MockRandomGenerator();
        }

        [Fact]
        public void ItExists()
        {
            _rand.Number();
        }

        [Fact]
        public void ItReturnsDefaultValue()
        {
            // Act
            var result = _rand.Number();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void ItCanReturnPredeterminedNumbers()
        {
            // Arrange
            _rand.SetNumbers(1, 2, 3, 4, 5);

            // Act
            var a = _rand.Number();
            var b = _rand.Number();
            var c = _rand.Number();
            var d = _rand.Number();
            var e = _rand.Number();

            // Arrange
            Assert.Equal(1, a);
            Assert.Equal(2, b);
            Assert.Equal(3, c);
            Assert.Equal(4, d);
            Assert.Equal(5, e);
        }

        [Fact]
        public void ItCanHaveAMaxRange()
        {
            // Arrange
            const int maxRange = 3;
            _rand.SetNumbers(1, 2, 3, 4, 5);

            // Act
            var a = _rand.Number(maxRange);
            var b = _rand.Number(maxRange);
            var c = _rand.Number(maxRange);
            var d = _rand.Number(maxRange);
            var e = _rand.Number(maxRange);

            // Arrange
            Assert.Equal(1, a);
            Assert.Equal(2, b);
            Assert.Equal(3, c);
            Assert.Equal(3, d);
            Assert.Equal(3, e);
        }

        [Fact]
        public void ItCanHaveAMinMaxRange()
        {
            // Arrange
            const int minRange = 2;
            const int maxRange = 3;
            _rand.SetNumbers(1, 2, 3, 4, 5);

            // Act
            var a = _rand.Number(minRange, maxRange);
            var b = _rand.Number(minRange, maxRange);
            var c = _rand.Number(minRange, maxRange);
            var d = _rand.Number(minRange, maxRange);
            var e = _rand.Number(minRange, maxRange);

            // Arrange
            Assert.Equal(2, a);
            Assert.Equal(2, b);
            Assert.Equal(3, c);
            Assert.Equal(3, d);
            Assert.Equal(3, e);
        }
    }
}
