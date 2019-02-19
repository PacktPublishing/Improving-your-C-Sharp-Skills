using System.Linq;

namespace SpeakerMeet.Repositories.Tests.InMemoryRepositoryTests
{
    internal class TestableEntityRepository : InMemoryRepository<TestEntity>
    {
        public IQueryable<TestEntity> EntityCollection => Entities.AsQueryable();
    }
}