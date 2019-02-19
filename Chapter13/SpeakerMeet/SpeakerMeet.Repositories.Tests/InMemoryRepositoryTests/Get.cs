using Xunit;

namespace SpeakerMeet.Repositories.Tests.InMemoryRepositoryTests
{
    public class Get
    {
        private readonly InMemoryRepository<TestEntity> _repo;

        public Get()
        {
            _repo = new InMemoryRepository<TestEntity>();
        }

        [Fact]
        public void ItExists()
        {
            // Act
            var reuslt = _repo.Get(0);
        }

        [Fact]
        public void ItReturnsAnEntityWhenFouund()
        {
            // Arrange
            var entity = _repo.Create(new TestEntity {
                Name = "Test Entity"
            });

            // Act
            var result = _repo.Get(entity.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Entity", result.Name);
        }

        [Fact]
        public void ItReturnsNullWhenNotFound()
        {
            // Act
            var result = _repo.Get(-1);

            // Assert
            Assert.Null(result);
        }
    }
}
