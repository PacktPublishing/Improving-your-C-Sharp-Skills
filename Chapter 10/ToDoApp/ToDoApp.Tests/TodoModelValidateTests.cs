using Xunit;

namespace ToDoApp.Tests
{
    public class TodoModelValidateTests
    {
        [Fact]
        public void OnNullADescriptionRequiredValidationErrorOccurs()
        {
            // Arrange
            var item = new Todo()
            {
                Description = null
            };

            // Act
            var exception = Record.Exception(() => item.Validate());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DescriptionRequiredException>(exception);
        }
    }
}
