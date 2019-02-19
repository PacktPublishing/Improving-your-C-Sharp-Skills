using Microsoft.AspNetCore.Mvc;
using SpeakerMeet.Exceptions;
using SpeakerMeet.Services.Interfaces;

namespace SpeakerMeet.API.Controllers
{
    [Route("api/[controller]")]
    public class SpeakerController : Controller
    {
        private readonly ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        // GET api/values
        [HttpGet]
        [Route("search")]
        public IActionResult Search(string searchString)
        {
            var speakers = _speakerService.Search(searchString);

            return Ok(speakers);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var speakers = _speakerService.GetAll();

            return Ok(speakers);
        }

        public IActionResult Get(int id)
        {
            try
            {
                var speaker = _speakerService.Get(id);
                return Ok(speaker);
            }
            catch (SpeakerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}