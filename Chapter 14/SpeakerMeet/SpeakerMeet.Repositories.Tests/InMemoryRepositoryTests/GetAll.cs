using System.Linq;
using Xunit;

namespace SpeakerMeet.Repositories.Tests.InMemoryRepositoryTests
{
    public class GetAll
    {
        private readonly InMemoryRepository<TestEntity> _repo;

        public GetAll()
        {
            _repo = new InMemoryRepository<TestEntity>();
        }

        [Fact]
        public void ItExists()
        {
            // Act
            var result = _repo.GetAll();
        }

        [Fact]
        public void ItReturnsNoEntitiesWhenThereAreNoEntities()
        {
            // Act
            var result = _repo.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IQueryable<TestEntity>>(result);
            Assert.Equal(0, result.Count());
        }

        [Fact]
        public void ItReturnsASinglEntityWhenOnlyOneEntityExists()
        {
            // Arrange
            _repo.Create(new TestEntity() {Name = "Test Entity"});

            // Act
            var result = _repo.GetAll().ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("Test Entity", result.First().Name);
        }

        [Fact]
        public void ItRetunrsManyEntitiesWhenManyEntitiesExist()
        {
            // Arrange
            _repo.Create(new TestEntity());
            _repo.Create(new TestEntity());
            _repo.Create(new TestEntity());

            // Act
            var result = _repo.GetAll().ToList();

            // Assert
            Assert.Equal(3, result.Count);
        }
    }
}
