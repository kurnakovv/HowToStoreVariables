using HowToStoreVariables.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HowToStoreVariablesTest.UnitTests
{
    public class EnvironmentControllerTests : IDisposable
    {
        public EnvironmentControllerTests()
        {
            Environment.SetEnvironmentVariable("User:Name", "MOCK_USER");
            Environment.SetEnvironmentVariable("User:Phone", "MOCK_PHONE_12345");
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable("User:Name", null);
            Environment.SetEnvironmentVariable("User:Phone", null);
        }

        [Fact]
        public void GetUserInfo()
        {
            var environmentController = new EnvironmentController();
            string result = environmentController.GetUserInfo();
            Assert.NotNull(result);
            Assert.Equal("User name: MOCK_USER, User phone: MOCK_PHONE_12345", result);
        }
    }
}
