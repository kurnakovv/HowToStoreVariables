using HowToStoreVariables.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HowToStoreVariables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppsettingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Variables _variables;
        private readonly Root _root;

        public AppsettingsController(
            IConfiguration configuration,
            Variables variables,
            Root root)
        {
            _configuration = configuration;
            _variables = variables;
            _root = root;
        }

        [HttpGet]
        public string Get()
        {
            string testConstant = _configuration["TestConstant"];
            return testConstant;
        }

        [HttpGet("GetBooleanConstant")]
        public bool GetBooleanConstant()
        {
            bool testConstantBoolean = _configuration.GetValue<bool>("TestConstantBoolean");
            return testConstantBoolean;
        }

        [HttpGet("GetArray")]
        public string GetArray()
        {
            string firstAndSecondAndThird = $"First: {_configuration["TestArray:First"]}\n Second: {_configuration["TestArray:Second"]}\n Third: {_configuration["TestArray:Third"]}";
            return firstAndSecondAndThird;
        }

        [HttpGet("GetObject")]
        public string GetObject()
        {
            return $"First: {_variables.First}, Second: {_variables.Second}, Third: {_variables.Third}";
        }

        [HttpGet("RewriteObject")]
        public string RewriteObject()
        {
            _variables.First = "Rewritten value";
            _variables.Second = "Rewritten value";
            _variables.Third = "Rewritten value";
            return $"First: {_variables.First}\nSecond: {_variables.Second}\nThird: {_variables.Third}";
        }

        [HttpGet("GetRootValueFromObject")]
        public string GetRootValueFromObject()
        {
            return _root.RootValue;
        }
    }
}
