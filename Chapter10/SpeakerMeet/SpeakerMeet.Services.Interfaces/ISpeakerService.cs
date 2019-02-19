using System.Collections.Generic;
using SpeakerMeet.DTO;

namespace SpeakerMeet.Services.Interfaces
{
    public interface ISpeakerService
    {
        IEnumerable<Speaker> Search(string searchString);
        IEnumerable<SpeakerSummary> GetAll();
        SpeakerDetail Get(int id);
    }
}
