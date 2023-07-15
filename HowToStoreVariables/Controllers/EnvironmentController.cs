using GenericEnv;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HowToStoreVariables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            string testVariable = Environment.GetEnvironmentVariable("TestVariable");
            return testVariable;
        }

        [HttpGet("GetUserInfo")]
        public string GetUserInfo()
        {
            return $"User name: {Environment.GetEnvironmentVariable("User:Name")}, User phone: {Environment.GetEnvironmentVariable("User:Phone")}";
        }

        [HttpGet("GetInvalidEnv")]
        public string GetInvalidEnv()
        {
            string invalidEnv = Environment.GetEnvironmentVariable("InvalidEnv");
            return invalidEnv;
        }

        [HttpGet("GetBooleanVariable")]
        public bool GetBooleanVariable() 
        {
            bool booleanVariable = GenericEnvironment.GetEnvironmentVariable<bool>("BooleanVariable");
            return booleanVariable;
        }
    }
}
