using System.Net;
using System.Net.Http;
using SpeakerMeet.DTO;
using Xunit;

namespace SpeakerMeet.Api.IntegrationTest.ControllerTests.SpeakerControllerTests
{
    [Collection("Controllers")]
    [Trait("Category", "Integration")]
    public class Get : IClassFixture<ServerFixture>
    {
        private readonly HttpClient _client;

        public Get(ServerFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async void ItShouldCallGetSpeaker()
        {
            // Act
            var response = await _client.GetAsync("/api/speaker/-1");

            Assert.NotNull(response);
        }

        [Fact]
        public async void ItShouldNotCallServer()
        {
            // Act
            var response = await _client.GetAsync("/api/speaker/-1");

            Assert.NotNull(response);
            Assert.False(response.Headers.Contains("Server"), "Should not contain server header");
        }

        [Fact]
        public async void ItShouldReturnError()
        {
            // Act
            var response = await _client.GetAsync("/api/speaker/-1");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async void ItShouldReturnSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/speaker/1");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void ItShouldReturnSpeaker()
        {
            // Act
            var response = await _client.GetAsync("/api/speaker/1");
            response.EnsureSuccessStatusCode();

            var speakerSummary = await response.Content.ReadAsJsonAsync<SpeakerDetail>();

            // Assert
            Assert.Equal(1, speakerSummary.Id);
        }
    }
}
