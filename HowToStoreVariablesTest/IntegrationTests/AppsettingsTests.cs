using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToStoreVariablesTest.IntegrationTests
{
    public class AppsettingsTests
    {
        private readonly IConfiguration _configuration;

        public AppsettingsTests()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Mock.json");
            _configuration = builder.Build();
        }

        [Fact]
        public void GetTestConstant()
        {
            string testConts = _configuration["TestConstant"];
            Assert.NotNull(testConts);
            Assert.Equal("This is my test constant from appsettings.json", testConts);
        }

        [Fact]
        public void GetMockConst()
        {
            string mockConst = _configuration["MockConst"];
            Assert.NotNull(mockConst);
            Assert.Equal("This is mock value", mockConst);
        }
    }
}
