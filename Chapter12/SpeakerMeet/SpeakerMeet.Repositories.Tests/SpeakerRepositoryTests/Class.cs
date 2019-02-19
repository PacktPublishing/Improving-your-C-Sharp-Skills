using SpeakerMeet.Models;
using SpeakerMeet.Repositories.Interfaces;
using Xunit;

namespace SpeakerMeet.Repositories.Tests.SpeakerRepositoryTests
{
    [Trait("Category", "SpeakerRepository")]
    public class Class
    {
        [Fact]
        public void ItExists()
        {
            var repo = new SpeakerRepository();
        }

        [Fact]
        public void ItIsARepository()
        {
            // Arrange / Act
            var repo = new SpeakerRepository();

            // Assert
            Assert.IsAssignableFrom<IRepository<Speaker>>(repo);
        }
    }
}
