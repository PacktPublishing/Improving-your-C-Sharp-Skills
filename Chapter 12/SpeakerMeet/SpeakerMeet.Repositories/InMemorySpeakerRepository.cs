using SpeakerMeet.Models;

namespace SpeakerMeet.Repositories
{
    public class InMemorySpeakerRepository : InMemoryRepository<Speaker>
    {
        protected override Speaker CloneEntity(Speaker entity)
        {
            return new Speaker
            {
                Id = entity.Id,
                Name = entity.Name,
                IsDeleted =  entity.IsDeleted,
                Location = entity.Location
            };
        }
    }
}
