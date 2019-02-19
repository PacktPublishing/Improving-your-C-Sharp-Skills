using Xunit;

namespace ToDoApp.Tests
{
    public class TodoModelTests
    {
        [Fact]
        public void ItHasDescription()
        {
            // Arrange
            var todo = new Todo();

            // Act
            todo.Description = "Test Description";
        }

        [Fact]
        public void ItHasIsComplete()
        {
            // Arrange
            var todo = new Todo();

            // Act
            todo.IsComplete = true;
        }
    }
}
