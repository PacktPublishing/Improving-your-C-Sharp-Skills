using System.Net;
using Microsoft.AspNetCore.Mvc;
using SpeakerMeet.DTO;
using SpeakerMeet.Services.Interfaces;

namespace SpeakerMeet.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Logon")]
    public class LogonController : Controller
    {
        private readonly ILogonService _service;

        public LogonController(ILogonService service)
        {
            _service = service;
        }

        public IActionResult Post(LoginAttempt attempt)
        {
            return _service.IsLogonValid(attempt) ?
                Ok("Logon Successful") :
                new ObjectResult("Username or Password invalid")
                {
                    StatusCode = (int?)HttpStatusCode.Unauthorized
                };
        }
    }
}