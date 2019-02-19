using System;
using SpeakerMeet.Repositories.Interfaces;
using Xunit;

namespace SpeakerMeet.Repositories.Tests.InMemoryRepositoryTests
{
    public class Delete
    {
        [Fact]
        public void ItThrowsNotImplementedException()
        {
            // Arrange
            var repo = new InMemoryRepository<TestEntity>();

            // Act
            var result = Record.Exception(() => repo.Delete(new TestEntity()));

            // Assert
            Assert.IsAssignableFrom<NotImplementedException>(result.GetBaseException());
            Assert.Equal("Delete is not available for TestEntity", result.Message);
        }
    }

    public class TestEntity : IIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
