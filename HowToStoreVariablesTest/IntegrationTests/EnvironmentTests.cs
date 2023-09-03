using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToStoreVariablesTest.IntegrationTests
{
    public class EnvironmentTests //: IDisposable
    {
        //public EnvironmentTests()
        //{
        //    Environment.SetEnvironmentVariable("TestVariable", "This is test variable from integration test");
        //}

        //public void Dispose()
        //{
        //    Environment.SetEnvironmentVariable("TestVariable", null);
        //}

        [Fact]
        public void GetEnvVariable()
        {
            string result = Environment.GetEnvironmentVariable("TestVariable");
            Assert.NotNull(result);
            Assert.Equal("This is test variable from integration test", result);
        }
    }
}
