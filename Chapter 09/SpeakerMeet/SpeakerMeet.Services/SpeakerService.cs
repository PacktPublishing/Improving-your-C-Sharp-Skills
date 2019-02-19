using System;
using System.Collections.Generic;
using System.Linq;
using SpeakerMeet.DTO;
using SpeakerMeet.Services.Interfaces;

namespace SpeakerMeet.Services
{
    public class SpeakerService : ISpeakerService
    {
        public IEnumerable<Speaker> Search(string searchString)
        {
            var hardCodedSpeakers = new List<Speaker>
            {
                new Speaker{Name = "Josh"},
                new Speaker{Name = "Joshua"},
                new Speaker{Name = "Joseph"},
                new Speaker{Name = "Bill"},
            };

            var speakers = hardCodedSpeakers.Where(x =>
                x.Name.StartsWith(searchString,
                    StringComparison.OrdinalIgnoreCase)).ToList();

            return speakers;
        }
    }
}
