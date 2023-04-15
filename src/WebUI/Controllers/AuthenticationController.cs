using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "SignUp")]
        public JsonResult SignUp()
        {
            return new JsonResult("Sign Up");
        }

        [HttpPost(Name = "SignIn")]
        public JsonResult SignIn()
        {
            return new JsonResult("Sign In");
        }
    }
}