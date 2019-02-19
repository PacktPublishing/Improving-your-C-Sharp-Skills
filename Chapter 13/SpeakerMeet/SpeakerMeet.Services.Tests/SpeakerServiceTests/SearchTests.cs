using System.Collections.Generic;
using System.Linq;
using SpeakerMeet.DTO;
using SpeakerMeet.Services.Interfaces;
using SpeakerMeet.Services.Tests.Factories;
using SpeakerMeet.Services.Tests.Fakes;
using Xunit;

namespace SpeakerMeet.Services.Tests.SpeakerServiceTests
{
    [Trait("Category", "SpeakerService")]
    public class Search
    {
        private readonly SpeakerService _speakerService;

        public Search()
        {
            var fakeRepository = new FakeRepository();
            var fakeGravatarService = new FakeGravatarService();

            SpeakerFactory.Create(fakeRepository);
            SpeakerFactory.Create(fakeRepository, name: "Josh");
            SpeakerFactory.Create(fakeRepository, name: "Joseph");
            SpeakerFactory.Create(fakeRepository, name: "Bill");

            _speakerService = new SpeakerService(fakeRepository, fakeGravatarService);
        }

        [Fact]
        public void ItHasSearchMethod()
        {
            _speakerService.Search("test");
        }

        [Fact]
        public void ItReturnsCollectionOfSpeakers()
        {
            // Arrange
            // Act
            var speakers = _speakerService.Search("test");

            // Assert
            Assert.NotNull(speakers);
            Assert.IsAssignableFrom<IEnumerable<Speaker>>(speakers);
        }

        [Fact]
        public void ItImplementsISpeakerService()
        {
            var speakerService = _speakerService;

            Assert.IsAssignableFrom<ISpeakerService>(speakerService);
        }

        [Fact]
        public void GivenExactMatchThenOneSpeakerInCollection()
        {
            // Arrange
            // Act
            var result = _speakerService.Search("Joshua");

            // Assert
            var speakers = result.ToList();
            Assert.Equal(1, speakers.Count);
            Assert.Equal("Joshua", speakers[0].Name);
        }

        [Theory]
        [InlineData("Joshua")]
        [InlineData("joshua")]
        [InlineData("JoShUa")]
        public void GivenCaseInsensitveMatchThenSpeakerInCollection(string searchString)
        {
            // Arrange
            // Act
            var result = _speakerService.Search(searchString);

            // Assert
            var speakers = result.ToList();
            Assert.Equal(1, speakers.Count);
            Assert.Equal("Joshua", speakers[0].Name);
        }

        [Fact]
        public void GivenNoMatchThenEmptyCollection()
        {
            // Arrange
            // Act
            var result = _speakerService.Search("ZZZ");

            // Assert
            var speakers = result.ToList();
            Assert.Equal(0, speakers.Count);
        }

        [Fact]
        public void Given3MatchThenCollectionWith3Speakers()
        {
            // Arrange
            // Act
            var result = _speakerService.Search("jos");

            // Assert
            var speakers = result.ToList();
            Assert.Equal(3, speakers.Count);
            Assert.True(speakers.Any(s => s.Name == "Josh"));
            Assert.True(speakers.Any(s => s.Name == "Joshua"));
            Assert.True(speakers.Any(s => s.Name == "Joseph"));
        }
    }
}