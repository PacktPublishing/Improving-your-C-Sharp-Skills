using Microsoft.AspNetCore.Mvc;
using SpeakerMeet.Services;

namespace SpeakerMeet.API.Controllers
{
    [Produces("application/json")]
    [Route("api/UserProfile")]
    public class UserProfileController : Controller
    {
        private readonly UserProfileService _service;

        public UserProfileController(UserProfileService service)
        {
            _service = service;
        }

        public IActionResult LogonUser(string username, string password)
        {
            var user = _service.GetUserProfile(username);

            if (user != null && _service.IsUserPasswordValid(user, password))
            {
                return Ok();
            }

            return Unauthorized();
        }
    }
}