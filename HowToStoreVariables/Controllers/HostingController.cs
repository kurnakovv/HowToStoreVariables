using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HowToStoreVariables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostingController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public HostingController(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            var constant = _configuration["Constant"]; // Constants (Camel case)
            var env = Environment.GetEnvironmentVariable("EnvVariable"); // Environment variables (Camel case)
            var secret = _configuration["TEST_SECRET"]; // Secrets local and GitHub (Upper case)
            var hostingRender = Environment.GetEnvironmentVariable("SECRET_ENV_VARIABLE"); // Secret env variable hosting (Upper case)
            return Environment.GetEnvironmentVariable("TEST_SECRET") ?? _configuration["TEST_SECRET"];
        }
    }
}
 