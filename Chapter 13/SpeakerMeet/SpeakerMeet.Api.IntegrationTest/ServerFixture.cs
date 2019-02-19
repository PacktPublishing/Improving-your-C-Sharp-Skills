using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpeakerMeet.API;
using SpeakerMeet.Models;

namespace SpeakerMeet.Api.IntegrationTest
{
    public class ServerFixture : IDisposable
    {
        public TestServer Server { get; }
        public HttpClient Client { get; }

        public ServerFixture()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<SpeakerMeetContext>(o =>
                        o.UseInMemoryDatabase("SpeakerMeetContext"));
                }));

            if (Server.Host.Services.GetService(typeof(SpeakerMeetContext)) is SpeakerMeetContext context)
            {
                context.Speakers.Add(new Speaker { Id = 1, Name = "Test", Location = "Location" });
                context.SaveChanges();
            }

            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            Server.Dispose();
            Client.Dispose();
        }
    }
}
