using System.Linq;
using SpeakerMeet.Services.Interfaces;
using Xunit;

namespace SpeakerMeet.Services.Tests.SpeakerServiceTests
{
    public class SearchTests
    {
        private readonly SpeakerService _speakerService;

        public SearchTests()
        {
            _speakerService = new SpeakerService();
        }

        [Fact(Skip = "No longer needed")]
        public void ItExists()
        {
            var speakerService = new SpeakerService();
        }

        [Fact]
        public void ItHasSearchMethod()
        {
            var speakerService = new SpeakerService();

            speakerService.Search("test");
        }

        [Fact]
        public void ItImplementsISpeakerService()
        {
            var speakerService = new SpeakerService();

            Assert.True(speakerService is ISpeakerService);
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
