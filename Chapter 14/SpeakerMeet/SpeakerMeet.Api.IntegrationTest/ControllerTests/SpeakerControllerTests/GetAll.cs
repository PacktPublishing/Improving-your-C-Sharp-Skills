using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using SpeakerMeet.DTO;
using Xunit;

namespace SpeakerMeet.Api.IntegrationTest.ControllerTests.SpeakerControllerTests
{
    [Collection("Controllers")]
    [Trait("Category", "Integration")]
    public class GetAll : IClassFixture<ServerFixture>
    {
        private readonly HttpClient _client;

        public GetAll(ServerFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async void ItShouldCallGetSpeakers()
        {
            // Act
            var response = await _client.GetAsync("/api/speaker");

            Assert.NotNull(response);
        }

        [Fact]
        public async void ItShouldNotCallServer()
        {
            // Act
            var response = await _client.GetAsync("/api/speaker");

            Assert.NotNull(response);
            Assert.False(response.Headers.Contains("Server"), "Should not contain server header");
        }

        [Fact]
        public async void ItShouldReturnSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/speaker/");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void ItShouldReturnSpeakers()
        {
            // Act
            var response = await _client.GetAsync("/api/speaker");
            response.EnsureSuccessStatusCode();

            var speakers = await response.Content.ReadAsJsonAsync<List<SpeakerSummary>>();

            // Assert
            Assert.Equal(1, speakers[0].Id);
        }
    }
}
