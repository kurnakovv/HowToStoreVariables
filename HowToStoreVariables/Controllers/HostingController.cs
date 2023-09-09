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
            return Environment.GetEnvironmentVariable("TEST_SECRET") ?? _configuration["TEST_SECRET"];
        }
    }
}
