using HowToStoreVariables.Controllers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToStoreVariablesTest.UnitTests
{
    public class AppsettingsControllerTests
    {
        private readonly IConfiguration _configuration;

        public AppsettingsControllerTests()
        {
            var appsettings = new Dictionary<string, string>()
            {
                { "TestConstant", "This is my test constant from appsettings.json" }
            };
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(appsettings)
                .Build();
        }

        [Fact]
        public void Get()
        {
            var appsettingsController = new AppsettingsController(_configuration, null, null);
            string result = appsettingsController.Get();
            Assert.NotNull(result);
        }

        [Fact]
        public void GetObject()
        {
            var appsettingsController = new AppsettingsController(null, new HowToStoreVariables.Constants.Variables
            {
                First = "First Mock",
                Second = "Second Mock",
                Third = "Third Mock",
            }, null);
            string result = appsettingsController.GetObject();
            Assert.NotNull(result);
        }
    }
}
