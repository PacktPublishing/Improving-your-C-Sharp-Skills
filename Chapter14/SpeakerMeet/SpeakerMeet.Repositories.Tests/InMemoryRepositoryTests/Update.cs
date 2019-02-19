using SpeakerMeet.Exceptions;
using Xunit;

namespace SpeakerMeet.Repositories.Tests.InMemoryRepositoryTests
{
    public class Update
    {
        private readonly InMemoryRepository<TestEntity> _repo;

        public Update()
        {
            _repo = new InMemoryRepository<TestEntity>();
        }

        [Fact]
        public void ItExists()
        {
            // Arrange
            var entity = _repo.Create(new TestEntity());

            // Act
            _repo.Update(entity);
        }

        [Fact]
        public void ItUpdatesAnEntity()
        {
            // Arrange
            var entity = _repo.Create(new TestEntity
            {
                Name = "Test Entity"
            });
            entity.Name = "New Name";
            
            // Act
            var result = _repo.Update(entity);

            // Assert
            Assert.Equal(entity.Name, result.Name);
        }

        [Fact]
        public void ItUpdatesAnEntityInTheRepository()
        {
            // Arrange
            var entity = _repo.Create(new TestEntity
            {
                Name = "Test Entity"
            });
            entity.Name = "New Name";

            // Act
            var updatedEntity = _repo.Update(entity);

            // Audit
            var result = _repo.Get(entity.Id);

            // Assert
            Assert.Equal("New Name", result.Name);
        }

        [Fact]
        public void ItThrowsNotFoundExceptionWhenEntityDoesNotExist()
        {
            // Arrange
            var entity = new TestEntity
            {
                Id = 5,
                Name = "Test Name"
            };

            // Act
            var result = Record.Exception(() => _repo.Update(entity));

            // Assert
            Assert.IsAssignableFrom<EntityNotFoundException>(result.GetBaseException());
        }
    }
}
