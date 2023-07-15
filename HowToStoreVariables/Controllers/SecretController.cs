using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HowToStoreVariables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SecretController(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            // Priority
            // "ASPNETCORE_ENVIRONMENT": "Test",
            // secrets.json -> appsettings.Test.json -> appsettings.json
            return _configuration["TEST_SECRET"];
        }

        [HttpGet("GetSecretAndAppsettings")]
        public string GetSecretAndAppsettings()
        {
            return $"secret: {_configuration["TEST_SECRET"]}\nappsettings: {_configuration["TestSecret"]}";
        }
    }
}
