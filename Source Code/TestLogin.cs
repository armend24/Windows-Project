using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Service
{
    class TestLogin
    {
        private readonly ILogger<TestLogin> _logger;
        private readonly IConfiguration _config;
        public TestLogin(ILogger<TestLogin> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void Shenim()
        {
            var test = _config["Folderi"];
            _logger.LogInformation($"Test3: {test}");
            _logger.LogError("Gabim");
            _logger.LogInformation("Ky eshte testi i katert me radhe");
        }
    }
}
