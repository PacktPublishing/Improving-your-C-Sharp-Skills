using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpeakerMeet.DTO;
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
    }
}