using System;
using System.Collections.Generic;
using Xunit;

namespace ToDoApp.Tests
{
    public class TodoListAddTests
    {
        [Fact]
        public void OnNullAnArgumentNullErrorOccurs()
        {
            // Arrange
            var todo = new TodoList();
            Todo item = null;

            // Act
            var exception = Record.Exception(() => todo.AddTodo(item));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void ItAddsATodoItemToTheTodoList()
        {
            // Arrange
            var todo = new TodoList();
            var item = new Todo()
            {
                Description = "Test"
            };

            // Act
            todo.AddTodo(item);

            // Assert
            Assert.Single(todo.Items);
        }

        [Fact]
        public void OnNullADescriptionRequiredValidationErrorOccurs()
        {
            // Arrange
            var todo = new TodoList();
            var item = new Todo()
            {
                Description = null
            };

            // Act
            var exception = Record.Exception(() => todo.AddTodo(item));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DescriptionRequiredException>(exception);
        }
    }

    internal class TodoList
    {
        private List<Todo> _items = new List<Todo>();

        public IEnumerable<Todo> Items
        {
            get
            {
                return _items;
            }
        }

        public TodoList()
        {
        }

        public void AddTodo(Todo item)
        {
            item = item ?? throw new ArgumentNullException();

            item.Validate();

            _items.Add(item);
        }
    }

    public class Todo
    {
        public string Description { get; set; }

        internal void Validate()
        {
            Description = Description ?? throw new DescriptionRequiredException();
        }
    }
}
