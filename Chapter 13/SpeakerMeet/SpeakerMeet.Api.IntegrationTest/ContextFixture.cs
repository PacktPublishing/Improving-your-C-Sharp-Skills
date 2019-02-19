using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpeakerMeet.Models;

namespace SpeakerMeet.Api.IntegrationTest
{
    public class ContextFixture : IDisposable
    {
        public SpeakerMeetContext Context { get; }

        public ContextFixture()
        {
            var options = new DbContextOptionsBuilder<SpeakerMeetContext>()
                .UseInMemoryDatabase("SpeakerMeetContext")
                .Options;

            Context = new SpeakerMeetContext(options);

            if (!Context.Speakers.Any())
            {
                Context.Speakers.Add(new Speaker { Id = 1, Name = "Test", Location = "Location" });
                Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
