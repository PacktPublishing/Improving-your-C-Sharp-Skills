using System.Collections.Generic;
using Xunit;

namespace ToDoApp.Tests
{
    public class ToDoApplicationTests
    {
        [Fact]
        public void TodoListExists()
        {
            var todo = new TodoList();

            Assert.NotNull(todo);
        }

        [Fact]
        public void CanGetTodos()
        {
            // Arrange
            var todo = new TodoList();

            // Act
            var result = todo.Items;

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Todo>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public void AddTodoExists()
        {
            // Arrange
            var todo = new TodoList();
            var item = new Todo()
            {
                Description = "Test"
            };

            // Act
            todo.AddTodo(item);
        }
    }
}
