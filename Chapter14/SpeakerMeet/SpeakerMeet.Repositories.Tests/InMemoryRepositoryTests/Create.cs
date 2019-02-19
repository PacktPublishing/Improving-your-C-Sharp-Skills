using System.Linq;
using Xunit;

namespace SpeakerMeet.Repositories.Tests.InMemoryRepositoryTests
{
    public class Create
    {
        private readonly TestableEntityRepository _repo;

        public Create()
        {
            _repo = new TestableEntityRepository();
        }

        [Fact]
        public void ItExists()
        {
            // Act
            var result = _repo.Create(new TestEntity());
        }

        [Fact]
        public void ItAddsAnEntityToTheRepository()
        {
            // Act
            var result = _repo.Create(new TestEntity());

            // Assert
            Assert.Equal(1, _repo.EntityCollection.Count());
        }

        [Fact]
        public void ItAssignsUniqueIdsToEachEntity()
        {
            // Act
            var entity1 = _repo.Create(new TestEntity());
            var entity2 = _repo.Create(new TestEntity());

            // Assert
            Assert.NotEqual(entity1.Id, entity2.Id);
        }
    }
}
