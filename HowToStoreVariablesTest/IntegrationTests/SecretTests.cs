﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToStoreVariablesTest.IntegrationTests
{
    public class SecretTests
    {
        private readonly IConfiguration _configuration;

        public SecretTests()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Program>();
            _configuration = builder.Build();
        }

        [Fact]
        public void Get_TEST_SECRET()
        {
            string secret = _configuration["TEST_SECRET"];
            if (secret == "CI_CD")
            {
                return;
            }
            Assert.NotNull(secret);
            Assert.Equal("This is very secret value (12345)", secret);
        }
    }
}
